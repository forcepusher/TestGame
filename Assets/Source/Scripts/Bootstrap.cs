using System.Threading;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Faraway.TestGame
{
    public class Bootstrap : IAsyncStartable
    {
        private SceneLoader _sceneLoader;

        private Bootstrap(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await _sceneLoader.LoadSceneAsync("Game");
        }
    }
}
