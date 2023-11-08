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
        private CharacterController _characterController;
        private IBehavior _characterBehavior;

        // IRunner implementation
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
        }

        public void Move(Vector3 motion)
        {
            _characterController.Move(motion);
        }

        public void ChangeBehavior(IBehavior behavior)
        {
            _characterBehavior = behavior;
        }
    }
}
