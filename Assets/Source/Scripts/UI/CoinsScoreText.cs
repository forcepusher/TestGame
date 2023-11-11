using MessagePipe;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Faraway.TestGame
{
    public class CoinsScoreText : MonoBehaviour
    {
        private IRunner _runner;
        private ISubscriber<int> _scoreSubscriber;

        private Text _text;

        [Inject]
        public void Construct(IRunner runner, ISubscriber<int> scoreSubscriber)
        {
            _runner = runner;
            _scoreSubscriber = scoreSubscriber;
        }

        private void Awake()
        {
            _text = GetComponent<Text>();
            _scoreSubscriber.Subscribe(scoreMessage => _text.text = scoreMessage.ToString());
        }
    }
}
