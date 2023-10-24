using System.Collections.Generic;
using Reflex.Attributes;
using UnityEngine;

namespace Faraway.TestGame
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour, IRunner, IEffectTarget
    {
        [SerializeField]
        private float _speed = 10f;
        [SerializeField]
        private float _jumpVelocity = 20f;
        [SerializeField]
        private float _gravity = -40f;

        private CharacterController _characterController;
        private readonly List<IEffectBehavior> _effectBehaviors = new();
        private IInputSource _inputSource;

        public Vector3 Position => transform.position;
        public Vector3 Velocity { get; set; }

        [Inject]
        public void Inject(IInputSource inputSource)
        {
            _inputSource = inputSource;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            Velocity = new Vector3(0f, 0f, _speed);
        }

        private void Update()
        {
            // Support for stacking coin behaviors
            for (int effectIterator = _effectBehaviors.Count - 1; effectIterator >= 0; effectIterator--)
            {
                IEffectBehavior effectBehavior = _effectBehaviors[effectIterator];

                effectBehavior.Tick(Time.deltaTime);

                if (effectBehavior.HasEnded)
                    _effectBehaviors.RemoveAt(effectIterator);
            }

            // Gravity
            Vector3 newVelocity = Velocity;
            if (_characterController.isGrounded)
                newVelocity.y = 0f;

            newVelocity.y += _gravity * Time.deltaTime;

            // Input
            var horizontalInput = new Vector3(_inputSource.HorizontalMovementDelta, 0f, 0f);
            if (_inputSource.Jump && _characterController.isGrounded)
                newVelocity.y = _jumpVelocity;

            Velocity = newVelocity;

            Move(Velocity * Time.deltaTime + horizontalInput);
        }

        public void Move(Vector3 motion)
        {
            _characterController.Move(motion);
        }

        public void AddEffect(IEffectBehavior effectBehavior)
        {
            _effectBehaviors.Add(effectBehavior);
        }
    }
}
