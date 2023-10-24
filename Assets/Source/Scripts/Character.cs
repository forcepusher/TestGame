using System.Collections.Generic;
using UnityEngine;

namespace Faraway.TestGame
{
    public class Character : MonoBehaviour, IRunner
    {
        [SerializeField]
        private float _speed = 10f;
        [SerializeField]
        private float _gravity = -20f;
        [SerializeField]
        private ContactFilter2D _collisionContactFilter = new();

        public float Speed { get => _speed; set => _speed = value; }
        public Vector2 Position => transform.position;
        private float _verticalVelocity = 0f;

        private Collider2D _collider;
        private readonly RaycastHit2D[] _raycastHits = new RaycastHit2D[32];
        private readonly List<IEffectBehavior> _effectBehaviors = new();

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            _verticalVelocity += _gravity * Time.deltaTime;
            Move(new Vector2(Speed * Time.deltaTime, _verticalVelocity * Time.deltaTime));

            // Support for stacking coin behaviors
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
            float collisionDistanceLimit = float.PositiveInfinity;

            int hitsCount = _collider.Cast(motion, _collisionContactFilter, _raycastHits, motion.magnitude);
            for (int hitIterator = 0; hitIterator < hitsCount; hitIterator++)
            {
                float hitDistance = _raycastHits[hitIterator].distance;

                if (hitDistance < collisionDistanceLimit)
                    collisionDistanceLimit = hitDistance;
            }

            motion = Vector2.ClampMagnitude(motion, collisionDistanceLimit);

            transform.Translate(motion);
        }
    }
}
