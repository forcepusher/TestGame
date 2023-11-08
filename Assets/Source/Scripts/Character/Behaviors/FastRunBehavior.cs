using UnityEngine;

namespace Faraway.TestGame
{
    public class FastRunBehavior : IBehavior
    {
        private const float Speed = 10f;
        private const float JumpVelocity = 20f;
        private const float Gravity = -40f;

        private readonly IRunner _runner;
        private Vector3 _velocity;

        public FastRunBehavior(IRunner runner)
        {
            _runner = runner;
        }

        public void Tick()
        {
            // Gravity
            Vector3 newVelocity = new Vector3(_velocity.x, _velocity.y, Speed);
            if (_runner.IsGrounded)
                newVelocity.y = 0f;

            newVelocity.y += Gravity * Time.deltaTime;

            // Horizontal movement and jump input
            var horizontalInput = new Vector3(_runner.InputSource.HorizontalMovementDelta, 0f, 0f);
            if (_runner.InputSource.Jump && _runner.IsGrounded)
                newVelocity.y = JumpVelocity;

            _velocity = newVelocity;

            _runner.Move(_velocity * Time.deltaTime + horizontalInput);
        }
    }
}
