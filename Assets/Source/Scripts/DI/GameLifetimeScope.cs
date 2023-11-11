using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace Faraway.TestGame
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<CrossPlatformInput>(Lifetime.Singleton).As<IInputSource, ITickable>();

            MessagePipeOptions messagePipeOptions = builder.RegisterMessagePipe();

            builder.RegisterBuildCallback(container => GlobalMessagePipe.SetProvider(container.AsServiceProvider()));

            builder.RegisterMessageBroker<int>(messagePipeOptions);
        }
    }
}
