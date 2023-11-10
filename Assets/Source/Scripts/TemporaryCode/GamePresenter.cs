using VContainer.Unity;

namespace Faraway.TestGame
{
    public class GamePresenter : ITickable
    {
        private readonly HelloWorldService _helloWorldService;

        public GamePresenter(HelloWorldService helloWorldService)
        {
            _helloWorldService = helloWorldService;
        }

        public void Tick()
        {
            _helloWorldService.Hello();
        }
    }
}
