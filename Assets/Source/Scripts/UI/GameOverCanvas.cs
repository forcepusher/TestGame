using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VContainer;

namespace Faraway.TestGame
{
    /// <summary>
    /// Canvas that that shows up on player death with stats and a restart button.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="UniRx"/> <see cref="Observable"/>s.
    /// </remarks>
    public class GameOverCanvas : MonoBehaviour
    {
        public Button RestartButton;
        public Text DistanceText;
        public Text ÑoinsText;

        private Canvas _canvas;
        private IRunner _runner;
        private SceneLoader _sceneLoader;

        [Inject]
        public void Construct(IRunner runner, SceneLoader sceneLoader)
        {
            _runner = runner;
            _sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _canvas.enabled = false;

            RestartButton.OnClickAsObservable().Subscribe(_ =>
            {
                _sceneLoader.LoadSceneAsync("Game");
            });

            Observable.EveryUpdate().First(_ => _runner.IsDead).Subscribe(_ =>
            {
                _canvas.enabled = true;
                DistanceText.text = $"Distance: {Mathf.RoundToInt(_runner.Position.z)}m";
                ÑoinsText.text = $"Coins: {_runner.Score}";
            });
        }
    }
}
