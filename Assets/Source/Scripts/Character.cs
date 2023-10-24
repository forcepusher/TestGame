using System.Collections.Generic;
using UnityEngine;

namespace Faraway.TestGame
{
    public class Character : MonoBehaviour, IMovable
    {
        [SerializeField]
        private ContactFilter2D _contactFilter = new();

        private readonly List<IEffectBehavior> _effectBehaviors = new();

        public Vector2 Position => transform.position;
        private Vector2 _velocity = Vector2.zero;

        private Collider2D _collider;
        private RaycastHit2D[] _raycastHit = new RaycastHit2D[32];

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            for (int effectIterator = _effectBehaviors.Count - 1; effectIterator >= 0; effectIterator--)
            {
                IEffectBehavior effectBehavior = _effectBehaviors[effectIterator];

                effectBehavior.Tick(Time.deltaTime);

                if (effectBehavior.HasEnded)
                    _effectBehaviors.RemoveAt(effectIterator);
            }
        }

        public void Move(Vector2 motion)
        {
            //_collider.Cast(motion, _raycastHit)
            transform.Translate(motion);
            
        }
    }
}
