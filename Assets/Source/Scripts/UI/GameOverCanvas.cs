using System;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Faraway.TestGame
{
    public class GameOverCanvas : IStartable, IDisposable
    {
        private IRunner _runner;
        private SceneLoader _sceneLoader;
        private GameOverCanvasView _gameOverCanvasView;

        private readonly CompositeDisposable _disposable = new();

        [Inject]
        public void Construct(GameOverCanvasView gameOverCanvasView, IRunner runner, SceneLoader sceneLoader)
        {
            _runner = runner;
            _sceneLoader = sceneLoader;
            _gameOverCanvasView = gameOverCanvasView;
        }

        public void Start()
        {
            _gameOverCanvasView.Canvas.enabled = false;

            _gameOverCanvasView.RestartButton.OnClickAsObservable().Subscribe(async _ =>
            {
                await _sceneLoader.LoadSceneAsync("Game");
            }).AddTo(_disposable);

            Observable.EveryUpdate().First(_ => _runner.IsDead).Subscribe(_ =>
            {
                _gameOverCanvasView.Canvas.enabled = true;
                _gameOverCanvasView.DistanceText.text = $"Distance: {Mathf.RoundToInt(_runner.Position.z)}m";
                _gameOverCanvasView.CoinsText.text = $"Coins: {_runner.Score}";
            }).AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
