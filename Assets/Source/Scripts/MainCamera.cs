using Reflex.Attributes;
using UnityEngine;

namespace Faraway.TestGame
{
    public class MainCamera : MonoBehaviour
    {
        private IRunner _followTarget;
        private Vector3 _offset;
        private Camera _camera;

        [Inject]
        public void Inject(IRunner runner)
        {
            _followTarget = runner;
            _offset = transform.position - _followTarget.Position;
        }

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void LateUpdate()
        {
            _camera.transform.position = _followTarget.Position + _offset;
        }
    }
}
