using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Faraway.TestGame
{
    public class CoinsScoreText : MonoBehaviour
    {
        private IRunner _runner;
        private Text _text;

        [Inject]
        public void Construct(IRunner runner)
        {
            _runner = runner;
        }

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void Update()
        {
            _text.text = _runner.Score.ToString();
        }
    }
}
