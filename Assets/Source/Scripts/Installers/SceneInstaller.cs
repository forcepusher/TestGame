using Reflex.Core;
using UnityEngine;

namespace Faraway.TestGame
{
    public class SceneInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerDescriptor containerDescriptor)
        {
            containerDescriptor.AddSingleton(typeof(CrossPlatformInput), typeof(IInputSource));
        }
    }
}
