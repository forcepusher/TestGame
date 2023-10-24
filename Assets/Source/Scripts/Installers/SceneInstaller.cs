using Reflex.Core;
using UnityEngine;

namespace Faraway.TestGame
{
    public class SceneInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField]
        private MainCamera _mainCamera;

        public void InstallBindings(ContainerDescriptor containerDescriptor)
        {
            containerDescriptor.AddSingleton(typeof(CrossPlatformInput), typeof(IInputSource));
            containerDescriptor.AddInstance(_mainCamera);
        }
    }
}
