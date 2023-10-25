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
        [SerializeField]
        private Button _restartButton;
        [SerializeField]
        private Text _distanceText;

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

            _restartButton.OnClickAsObservable().Subscribe(_ =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });

            Observable.EveryUpdate().First(_ => _runner.IsDead).Subscribe(_ =>
            {
                _canvas.enabled = true;
                _distanceText.text = $"Distance: {Mathf.RoundToInt(_runner.Position.z)} meters";
            });
        }
    }
}
