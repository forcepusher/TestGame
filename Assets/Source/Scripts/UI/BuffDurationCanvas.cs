using VContainer;
using VContainer.Unity;
using UniRx;

namespace Faraway.TestGame
{
    public class BuffDurationCanvas : ITickable, IStartable
    {
        private BuffDurationCanvasView _buffDurationCanvasView;
        private IRunner _runner;

        [Inject]
        public void Construct(IRunner runner, BuffDurationCanvasView buffDurationCanvasView)
        {
            _runner = runner;
            _buffDurationCanvasView = buffDurationCanvasView;
        }

        public void Start()
        {
            _runner.EffectBehaviors.ObserveAdd().Subscribe(_effectBehavior => _buffDurationCanvasView.AddEffectView(_effectBehavior.Value));
            _runner.EffectBehaviors.ObserveRemove().Subscribe(_effectBehavior => _buffDurationCanvasView.RemoveEffectView(_effectBehavior.Value));
        }

        public void Tick()
        {
            _buffDurationCanvasView.UpdateEffectViews();
        }
    }
}
