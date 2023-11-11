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
        [SerializeField]
        private BuffDurationCanvasView _buffDurationCanvasView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_mainCamera).AsSelf();
            builder.RegisterInstance(_playerCharacter).As<IRunner>();
            builder.RegisterInstance(_gameOverCanvasView).AsSelf();
            builder.RegisterInstance(_coinsScoreTextView).AsSelf();
            builder.RegisterInstance(_buffDurationCanvasView).AsSelf();

            builder.Register<GameOverCanvas>(Lifetime.Singleton).As<IStartable>();
            builder.Register<CoinsScoreText>(Lifetime.Singleton).As<IStartable>();
            builder.Register<BuffDurationCanvas>(Lifetime.Singleton).As<IStartable, ITickable>();

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
