using MessagePipe;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Faraway.TestGame
{
    public class CoinsScoreText : MonoBehaviour
    {
        private ISubscriber<CoinsScoreMessage> _scoreSubscriber;
        private CoinsScoreMessageFilter _scoreMessageFilter;

        private Text _text;

        [Inject]
        public void Construct(ISubscriber<CoinsScoreMessage> scoreSubscriber, CoinsScoreMessageFilter scoreMessageFilter)
        {
            _scoreSubscriber = scoreSubscriber;
            _scoreMessageFilter = scoreMessageFilter;
        }

        private void Awake()
        {
            _text = GetComponent<Text>();
            _scoreSubscriber.Subscribe(scoreMessage => _text.text = scoreMessage.Score.ToString(), _scoreMessageFilter);
        }
    }
}
