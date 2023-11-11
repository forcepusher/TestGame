using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Faraway.TestGame
{
    public class SceneLoader
    {
        private GameLifetimeScope _gameLifetimeScope;

        public SceneLoader(GameLifetimeScope gameLifetimeScope)
        {
            _gameLifetimeScope = gameLifetimeScope;
        }

        public async UniTask LoadSceneAsync(string sceneName)
        {
            using (GameLifetimeScope.EnqueueParent(_gameLifetimeScope))
            {
                await SceneManager.LoadSceneAsync(sceneName);
            }
        }
    }
}
