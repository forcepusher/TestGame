using VContainer;
using VContainer.Unity;

namespace Faraway.TestGame
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<Bootstrap>(Lifetime.Singleton).As<IAsyncStartable>();

            builder.Register<CrossPlatformInput>(Lifetime.Singleton).As<IInputSource, ITickable>();
        }
    }
}
