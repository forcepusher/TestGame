using System.Collections;
using System.Collections.Generic;
using MessagePipe;
using UniRx;
using UnityEngine;
using VContainer;

namespace Faraway.TestGame
{
    /// <summary>
    /// Player script responsible for movement controls and maintaining his <see cref="IEffectBehavior"/>s.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour, IRunner
    {
        [SerializeField]
        private float _speed = 10f;
        [SerializeField]
        private float _jumpVelocity = 15f;
        [SerializeField]
        private float _gravity = -40f;
        [SerializeField]
        private float _movementOffset = 2.2f;
        [SerializeField]
        private float _horizontalSpeed = 20f;

        private CharacterController _characterController;
        private Animator _animator;
        private IInputSource _inputSource;
        private IPublisher<CoinsScoreMessage> _scorePublisher;

        private int _movementLane = 0;

        // IRunner implementation
        public Vector3 Position => transform.position;
        public Vector3 Velocity { get; set; }
        public bool IsDead { get; set; } = false;
        public ReactiveCollection<IEffectBehavior> EffectBehaviors { get; } = new();
        public int Score { get; private set; }

        [Inject]
        public void Construct(IInputSource inputSource, IPublisher<CoinsScoreMessage> scorePublisher)
        {
            _inputSource = inputSource;
            _scorePublisher = scorePublisher;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponentInChildren<Animator>();
            Velocity = new Vector3(0f, 0f, _speed);
        }

        private void Update()
        {
            _animator.SetBool("Death", IsDead);

            if (IsDead)
                return;

            // Support for stacking coin behaviors
            for (int effectIteration = EffectBehaviors.Count - 1; effectIteration >= 0; effectIteration--)
            {
                IEffectBehavior effectBehavior = EffectBehaviors[effectIteration];

                effectBehavior.Tick(Time.deltaTime);

                if (effectBehavior.OutOfTime)
                {
                    effectBehavior.End();
                    EffectBehaviors.RemoveAt(effectIteration);
                }
            }

            // Gravity
            Vector3 newVelocity = Velocity;
            if (_characterController.isGrounded)
                newVelocity.y = 0f;

            newVelocity.y += _gravity * Time.deltaTime;

            // Horizontal movement and jump input
            if (_inputSource.MoveLeft && _movementLane > -1)
            {
                StartCoroutine(HorizontalMove(-1));
                _movementLane -= 1;
            }

            if (_inputSource.MoveRight && _movementLane < 1)
            {
                StartCoroutine(HorizontalMove(1));
                _movementLane += 1;
            }

            if (_inputSource.Jump && _characterController.isGrounded)
            {
                newVelocity.y = _jumpVelocity;
                _animator.SetBool("Jump", true);
                StartCoroutine(StopJump(0.75f));
            }

            Velocity = newVelocity;

            Move(Velocity * Time.deltaTime);

            _animator.SetFloat("RunSpeed", Velocity.z);
            // This is a crutch. Animator logic should be separated.
            _animator.SetBool("Flying", Position.y > 1f && !_animator.GetBool("Jump"));
        }

        public void Move(Vector3 motion)
        {
            _characterController.Move(motion);
        }

        public void AddEffect(IEffectBehavior effectBehavior)
        {
            for (int effectIteration = EffectBehaviors.Count - 1; effectIteration >= 0; effectIteration--)
            {
                IEffectBehavior existingEffectBehavior = EffectBehaviors[effectIteration];
                if (existingEffectBehavior.StackingIdentifier == effectBehavior.StackingIdentifier)
                {
                    existingEffectBehavior.End();
                    EffectBehaviors.RemoveAt(effectIteration);
                }    
            }

            EffectBehaviors.Add(effectBehavior);
        }

        public void IncreaseScore(int amount)
        {
            Score += amount;
            _scorePublisher.Publish(new CoinsScoreMessage(Score));
        }

        private IEnumerator StopJump(float delay)
        {
            yield return new WaitForSeconds(delay);
            _animator.SetBool("Jump", false);
        }

        private IEnumerator HorizontalMove(int direction)
        {
            float remainingOffset = _movementOffset;
            while (remainingOffset > 0f)
            {
                float movement = _horizontalSpeed * Time.deltaTime;
                movement = Mathf.Min(movement, remainingOffset);

                Move(new Vector3(movement * direction, 0f, 0f));

                remainingOffset -= movement;
                yield return null;
            }
        }
    }
}
