using System.Collections.Generic;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Faraway.TestGame
{
    public class BuffDurationCanvas : MonoBehaviour
    {
        [SerializeField]
        private Image _buffDurationImage;

        private IRunner _runner;

        private List<IEffectBehavior> _trackedEffects = new();
        private List<Image> _buffDurationImages = new();

        [Inject]
        public void Inject(IRunner runner)
        {
            _runner = runner;
        }

        private void Awake()
        {
            _buffDurationImage.enabled = false;
        }

        private void Update()
        {
            foreach (IEffectBehavior runnerEffectBehavior in _runner.EffectBehaviors)
            {
                if (!_trackedEffects.Contains(runnerEffectBehavior))
                {
                    Image buffDurationImage = Instantiate(_buffDurationImage, transform);
                    buffDurationImage.rectTransform.SetAsFirstSibling();
                    buffDurationImage.color = runnerEffectBehavior.BuffColor;
                    buffDurationImage.enabled = true;
                    _buffDurationImages.Add(buffDurationImage);
                    _trackedEffects.Add(runnerEffectBehavior);
                }
            }

            for (int effectIteration = _trackedEffects.Count - 1; effectIteration >= 0; effectIteration--)
            {
                IEffectBehavior effectBehavior = _trackedEffects[effectIteration];
                Image durationImage = _buffDurationImages[effectIteration];

                if (!_runner.EffectBehaviors.Contains(effectBehavior))
                {
                    _trackedEffects.RemoveAt(effectIteration);
                    _buffDurationImages.RemoveAt(effectIteration);
                    Destroy(durationImage.gameObject);
                }
                else
                {
                    durationImage.fillAmount = effectBehavior.TimeRemaining;
                }
            }
        }
    }
}
