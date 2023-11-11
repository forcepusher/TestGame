using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace Faraway.TestGame
{
    public class CoinsScoreText : IStartable
    {
        private CoinsScoreTextView _coinsScoreTextView;
        private ISubscriber<CoinsScoreMessage> _scoreSubscriber;
        private CoinsScoreMessageFilter _scoreMessageFilter;

        [Inject]
        public void Construct(CoinsScoreTextView coinsScoreTextView, ISubscriber<CoinsScoreMessage> scoreSubscriber, CoinsScoreMessageFilter scoreMessageFilter)
        {
            _scoreSubscriber = scoreSubscriber;
            _scoreMessageFilter = scoreMessageFilter;
            _coinsScoreTextView = coinsScoreTextView;
        }

        public void Start()
        {
            _scoreSubscriber.Subscribe(scoreMessage => _coinsScoreTextView.Text.text = scoreMessage.Score.ToString(), _scoreMessageFilter);
        }
    }
}
