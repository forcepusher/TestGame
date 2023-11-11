using MessagePipe;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Faraway.TestGame
{
    public class CoinsScoreText : MonoBehaviour
    {
        private ISubscriber<int> _scoreSubscriber;
        private CoinsScoreMessageFilter _scoreMessageFilter;

        private Text _text;

        [Inject]
        public void Construct(ISubscriber<int> scoreSubscriber, CoinsScoreMessageFilter scoreMessageFilter)
        {
            _scoreSubscriber = scoreSubscriber;
            _scoreMessageFilter = scoreMessageFilter;
        }

        private void Awake()
        {
            _text = GetComponent<Text>();
            _scoreSubscriber.Subscribe(scoreMessage => _text.text = scoreMessage.ToString(), _scoreMessageFilter);
        }
    }
}
