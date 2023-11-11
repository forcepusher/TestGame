using System.Collections;
using UnityEngine;

namespace Faraway.TestGame
{
    public class FadeTimerView : MonoBehaviour
    {
        [SerializeField]
        private float _fadeDuration = 0.5f;
        [SerializeField]
        private float _delayDuration = 3f;

        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(_delayDuration);

            float remainingFadeDuration = _fadeDuration;

            while (remainingFadeDuration > 0)
            {
                remainingFadeDuration -= Time.deltaTime;
                _canvasGroup.alpha = remainingFadeDuration / _fadeDuration;
                yield return null;
            }
        }
    }
}
