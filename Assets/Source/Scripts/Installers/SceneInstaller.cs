using Reflex.Core;
using UnityEngine;

namespace Faraway.TestGame
{
    public class SceneInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField]
        private MainCamera _mainCamera;
        [SerializeField]
        private Character _playerCharacter;

        public void InstallBindings(ContainerDescriptor containerDescriptor)
        {
            containerDescriptor.AddSingleton(typeof(CrossPlatformInput), typeof(IInputSource));
            containerDescriptor.AddInstance(_mainCamera);
            containerDescriptor.AddInstance(_playerCharacter, typeof(IRunner));
        }
    }
}
