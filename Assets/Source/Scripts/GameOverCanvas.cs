using Reflex.Attributes;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Faraway.TestGame
{
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

            _restartButton.OnClickAsObservable().Subscribe(_ =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });


        }
    }
}
