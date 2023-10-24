using System.Collections.Generic;
using UnityEngine;

namespace Faraway.TestGame
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour, IRunner, IEffectTarget
    {
        [SerializeField]
        private float _speed = 10f;
        [SerializeField]
        private float _gravity = -20f;

        private CharacterController _characterController;
        private readonly List<IEffectBehavior> _effectBehaviors = new();

        public Vector3 Position => transform.position;
        public Vector3 Velocity { get; set; }

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
            else
                newVelocity.y += _gravity * Time.deltaTime;

            Velocity = newVelocity;

            Move(Velocity * Time.deltaTime);
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
