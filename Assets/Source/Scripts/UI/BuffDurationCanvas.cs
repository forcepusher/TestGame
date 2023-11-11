using VContainer;
using VContainer.Unity;
using UniRx;
using System;

namespace Faraway.TestGame
{
    public class BuffDurationCanvas : ITickable, IStartable, IDisposable
    {
        private BuffDurationCanvasView _buffDurationCanvasView;
        private IRunner _runner;

        private CompositeDisposable _disposable = new();

        [Inject]
        public void Construct(IRunner runner, BuffDurationCanvasView buffDurationCanvasView)
        {
            _runner = runner;
            _buffDurationCanvasView = buffDurationCanvasView;
        }

        public void Start()
        {
            _runner.EffectBehaviors.ObserveAdd().Subscribe(_effectBehavior => _buffDurationCanvasView.AddEffectView(_effectBehavior.Value)).AddTo(_disposable);
            _runner.EffectBehaviors.ObserveRemove().Subscribe(_effectBehavior => _buffDurationCanvasView.RemoveEffectView(_effectBehavior.Value)).AddTo(_disposable);
        }

        public void Tick()
        {
            _buffDurationCanvasView.UpdateEffectViews();
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
