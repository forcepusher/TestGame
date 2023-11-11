using VContainer;
using VContainer.Unity;

namespace Faraway.TestGame
{
    public class BuffDurationCanvas : ITickable
    {
        private IRunner _runner;

        [Inject]
        public void Construct(IRunner runner)
        {
            _runner = runner;
        }

        public void Tick()
        {
            
        }

        //private void Update()
        //{
        //    foreach (IEffectBehavior runnerEffectBehavior in _runner.EffectBehaviors)
        //    {
        //        if (!_trackedEffects.Contains(runnerEffectBehavior))
        //        {
        //            Image buffDurationImage = Instantiate(_buffDurationImage, transform);
        //            buffDurationImage.rectTransform.SetAsFirstSibling();
        //            buffDurationImage.color = runnerEffectBehavior.BuffColor;
        //            buffDurationImage.enabled = true;
        //            _buffDurationImages.Add(buffDurationImage);
        //            _trackedEffects.Add(runnerEffectBehavior);
        //        }
        //    }

        //    for (int effectIteration = _trackedEffects.Count - 1; effectIteration >= 0; effectIteration--)
        //    {
        //        IEffectBehavior effectBehavior = _trackedEffects[effectIteration];
        //        Image durationImage = _buffDurationImages[effectIteration];

        //        if (!_runner.EffectBehaviors.Contains(effectBehavior))
        //        {
        //            _trackedEffects.RemoveAt(effectIteration);
        //            _buffDurationImages.RemoveAt(effectIteration);
        //            Destroy(durationImage.gameObject);
        //        }
        //        else
        //        {
        //            durationImage.fillAmount = effectBehavior.TimeRemaining;
        //        }
        //    }
        //}
    }
}
