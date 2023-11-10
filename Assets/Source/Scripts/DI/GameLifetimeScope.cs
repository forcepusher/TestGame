using VContainer;
using VContainer.Unity;

namespace Faraway.TestGame
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<HelloWorldService>(Lifetime.Singleton).AsSelf();
            //builder.Register<GamePresenter>(Lifetime.Singleton).As<GamePresenter, ITickable>();
            builder.Register<GamePresenter>(Lifetime.Singleton).AsSelf();
            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            {
                entryPoints.Add<GamePresenter>();
            });
        }
    }
}
