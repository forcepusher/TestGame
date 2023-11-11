using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Faraway.TestGame
{
    /// <summary>
    /// Canvas that that shows up on player death with stats and a restart button.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="UniRx"/> <see cref="Observable"/>s.
    /// </remarks>
    public class GameOverCanvasView : MonoBehaviour
    {
        public Button RestartButton;
        public Text DistanceText;
        public Text CoinsText;
        public Canvas Canvas;
    }
}
