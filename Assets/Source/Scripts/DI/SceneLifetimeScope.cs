using MessagePipe;
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
            builder.RegisterInstance(_mainCamera).As<MainCamera>();
            builder.RegisterInstance(_playerCharacter).As<IRunner>();

            MessagePipeOptions messagePipeOptions = builder.RegisterMessagePipe();

#if UNITY_EDITOR
            messagePipeOptions.EnableCaptureStackTrace = true;
            builder.RegisterBuildCallback(container => GlobalMessagePipe.SetProvider(container.AsServiceProvider()));
#endif

            builder.RegisterMessageHandlerFilter<CoinsScoreMessageFilter>();
            builder.RegisterMessageBroker<CoinsScoreMessage>(messagePipeOptions);
        }
    }
}
