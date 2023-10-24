using System.Collections.Generic;
using UnityEngine;

namespace Faraway.TestGame
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour, IRunner
    {
        [SerializeField]
        private float _speed = 10f;
        [SerializeField]
        private float _gravity = -20f;

        public float Speed { get => _speed; set => _speed = value; }
        public Vector3 Position => transform.position;
        private float _verticalVelocity = 0f;

        private readonly List<IEffectBehavior> _effectBehaviors = new();

        private CharacterController _characterController;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
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

            Move(new Vector3(0f, _verticalVelocity * Time.deltaTime, Speed * Time.deltaTime));

            if (_characterController.isGrounded)
                _verticalVelocity = 0f;
            else
                _verticalVelocity += _gravity * Time.deltaTime;
        }

        public void Move(Vector3 motion)
        {
            _characterController.Move(motion);
        }
    }
}
