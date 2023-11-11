using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Faraway.TestGame
{
    public class BuffDurationCanvasView : MonoBehaviour
    {
        [SerializeField]
        private Image _buffDurationImage;

        private readonly Dictionary<IEffectBehavior, Image> _trackedEffects = new();

        private void Awake()
        {
            _buffDurationImage.enabled = false;
        }

        public void AddEffectView(IEffectBehavior effect)
        {
            Image buffDurationImage = Instantiate(_buffDurationImage, transform);
            buffDurationImage.rectTransform.SetAsFirstSibling();
            buffDurationImage.color = effect.BuffColor;
            buffDurationImage.enabled = true;
            _trackedEffects.Add(effect, buffDurationImage);
        }

        public void RemoveEffectView(IEffectBehavior effect)
        {
            Image trackedEffectImage = _trackedEffects[effect];
            _trackedEffects.Remove(effect);
            Destroy(trackedEffectImage);
        }

        public void UpdateEffectViews()
        {
            foreach (KeyValuePair<IEffectBehavior, Image> effect in _trackedEffects)
                effect.Value.fillAmount = effect.Key.TimeRemaining;
        }
    }
}
