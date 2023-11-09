using Agava.WebUtility;
using UnityEngine;
using UnityEngine.UI;

namespace Faraway.TestGame
{
    public class ControlsText : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Text>().text = Device.IsMobile ? "Swipe Left/Right/Up" : "Use A/D/Space keys";
        }
    }
}
