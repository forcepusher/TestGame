using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Faraway.TestGame
{
    public class CoinsText : MonoBehaviour
    {
        private IRunner _runner;
        private Text _text;

        [Inject]
        public void Inject(IRunner runner)
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
