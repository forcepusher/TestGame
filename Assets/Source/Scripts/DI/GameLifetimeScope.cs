using VContainer;
using VContainer.Unity;

namespace Faraway.TestGame
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<HelloWorldService>(Lifetime.Singleton);
            builder.Register<GamePresenter>(Lifetime.Singleton);
            builder.RegisterEntryPoint<GamePresenter>();
        }
    }
}
