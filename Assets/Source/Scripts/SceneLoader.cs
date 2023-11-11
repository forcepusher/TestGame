using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Faraway.TestGame
{
    public class SceneLoader
    {
        private readonly GameLifetimeScope _gameLifetimeScope;

        public SceneLoader(GameLifetimeScope gameLifetimeScope)
        {
            _gameLifetimeScope = gameLifetimeScope;
        }

        public async UniTask LoadSceneAsync(string sceneName)
        {
            using (LifetimeScope.EnqueueParent(_gameLifetimeScope))
            {
                await SceneManager.LoadSceneAsync(sceneName);
            }
        }
    }
}
