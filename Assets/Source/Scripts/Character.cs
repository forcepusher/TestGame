using System.Collections.Generic;
using UnityEngine;

namespace Faraway.TestGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : MonoBehaviour, IRigidbody
    {
        public List<IEffectBehavior> EffectBehaviors;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public Vector2 Position { get => _rigidbody.position; set => _rigidbody.position = value; }

        public void Move()
        {
            //_rigidbody.MovePosition
        }

        private void FixedUpdate()
        {
            for (int effectIterator = EffectBehaviors.Count - 1; effectIterator >= 0; effectIterator--)
            {
                IEffectBehavior effectBehavior = EffectBehaviors[effectIterator];

                effectBehavior.Tick();

                if (effectBehavior.HasEnded)
                    EffectBehaviors.RemoveAt(effectIterator);
            }
        }
    }
}
