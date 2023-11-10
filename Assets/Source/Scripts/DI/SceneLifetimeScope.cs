using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Faraway.TestGame
{
    public class SceneLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private MainCamera _mainCamera;
        [SerializeField]
        private Character _playerCharacter;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<CrossPlatformInput>(Lifetime.Singleton).As<IInputSource, ITickable>();
            builder.RegisterInstance(_mainCamera).AsSelf();
            builder.RegisterInstance(_playerCharacter).As<IRunner>();
        }
    }
}
