using UnityEngine;

namespace Faraway.TestGame
{
    public class MainCamera : MonoBehaviour
    {
        [SerializeField]
        private Transform _followTarget;

        private Vector3 _offset;
        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            _offset = transform.position - _followTarget.position;
        }

        private void LateUpdate()
        {
            _camera.transform.position = _followTarget.position + _offset;
        }
    }
}
