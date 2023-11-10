using Reflex.Attributes;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

        [Inject]
        public void Inject(IRunner runner)
        {
            _runner = runner;
        }

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _canvas.enabled = false;

            RestartButton.OnClickAsObservable().Subscribe(_ =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
