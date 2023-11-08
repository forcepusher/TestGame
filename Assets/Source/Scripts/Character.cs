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
        private const float Speed = 10f;
        private const float JumpVelocity = 20f;
        private const float Gravity = -40f;

        private CharacterController _characterController;
        private IBehavior _characterBehavior;

        // IRunner implementation
        public Vector3 Velocity { get; set; }
        public Vector3 Position => transform.position;
        public bool IsDead { get; set; } = false;
        public bool IsGrounded => _characterController.isGrounded;
        public IInputSource InputSource { get; private set; }

        [Inject]
        public void Inject(IInputSource inputSource)
        {
            InputSource = inputSource;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _characterBehavior = new FastRunBehavior(this);
        }

        private void Update()
        {
            _characterBehavior.Tick();

            // Gravity
            Vector3 newVelocity = Velocity;
            if (_characterController.isGrounded)
                newVelocity.y = 0f;

            newVelocity.y += Gravity * Time.deltaTime;

            // Horizontal movement and jump input
            var horizontalInput = new Vector3(_inputSource.HorizontalMovementDelta, 0f, 0f);
            if (_inputSource.Jump && _characterController.isGrounded)
                newVelocity.y = _jumpVelocity;

            Velocity = newVelocity;

            Move(ClampedVelocity * Time.deltaTime + horizontalInput);
        }

        public void Move(Vector3 motion)
        {
            _characterController.Move(motion);
        }

        public void ChangeBehavior(IBehavior behavior)
        {
            _characterBehavior.End();
            _characterBehavior = behavior;
            _characterBehavior.Start();
        }
    }
}
