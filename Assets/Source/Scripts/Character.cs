using System.Collections.Generic;
using Reflex.Attributes;
using UnityEngine;

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
        private float _jumpVelocity = 20f;
        [SerializeField]
        private float _gravity = -40f;
        [SerializeField]
        private float _minimumSpeed = 3f;
        [SerializeField]
        private float _maximumSpeed = 40f;

        private CharacterController _characterController;
        private Animator _animator;
        private IInputSource _inputSource;

        // IRunner implementation
        public Vector3 Position => transform.position;
        public Vector3 Velocity { get; set; }
        public bool IsDead { get; set; } = false;
        public List<IEffectBehavior> EffectBehaviors { get; } = new();

        [Inject]
        public void Inject(IInputSource inputSource)
        {
            _inputSource = inputSource;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponentInChildren<Animator>();
            Velocity = new Vector3(0f, 0f, _speed);
        }

        private void Update()
        {
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
            var horizontalInput = new Vector3(_inputSource.HorizontalMovementDelta, 0f, 0f);
            if (_inputSource.Jump && _characterController.isGrounded)
                newVelocity.y = _jumpVelocity;

            Velocity = newVelocity;

            Move(Velocity * Time.deltaTime + horizontalInput);

            _animator.SetFloat("RunSpeed", Velocity.z);
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
    }
}
