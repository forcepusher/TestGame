using System;
using MessagePipe;

namespace Faraway.TestGame
{
    public class CoinsScoreMessageFilter : MessageHandlerFilter<CoinsScoreMessage>
    {
        public override void Handle(CoinsScoreMessage message, Action<CoinsScoreMessage> next)
        {
            next.Invoke(new CoinsScoreMessage(message.Score + 10));
        }
    }
}
