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
        [SerializeField]
        private GameOverCanvasView _gameOverCanvasView;
        [SerializeField]
        private CoinsScoreTextView _coinsScoreTextView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_mainCamera).AsSelf();
            builder.RegisterInstance(_playerCharacter).As<IRunner>();
            builder.RegisterInstance(_gameOverCanvasView).AsSelf();
            builder.RegisterInstance(_coinsScoreTextView).AsSelf();

            builder.Register<GameOverCanvas>(Lifetime.Singleton).As<IStartable>();
            builder.Register<CoinsScoreText>(Lifetime.Singleton).As<IStartable>();

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
