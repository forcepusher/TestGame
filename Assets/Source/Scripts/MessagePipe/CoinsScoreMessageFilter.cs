using System;
using MessagePipe;

namespace Faraway.TestGame
{
    public class CoinsScoreMessageFilter : MessageHandlerFilter<int>
    {
        public override void Handle(int message, Action<int> next)
        {
            next.Invoke(message + 10);
        }
    }
}
