using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Faraway.TestGame
{
    public class Bootstrap : IAsyncStartable
    {
        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await SceneManager.LoadSceneAsync("Game");
        }
    }
}
