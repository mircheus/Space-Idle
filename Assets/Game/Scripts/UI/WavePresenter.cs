using System;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI
{
    public class WavePresenter : IInitializable, IDisposable
    {
        private WaveView _waveView;
        private SignalBus _signalBus;
        
        public WavePresenter(WaveView waveView, SignalBus signalBus)
        {
            _waveView = waveView;
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            _waveView.StartWaveButtonPressed += OnStartWaveButtonPressed;
            _waveView.ShowPanel();
        }

        public void Dispose()
        {
            _waveView.StartWaveButtonPressed -= OnStartWaveButtonPressed;
        }

        private void OnStartWaveButtonPressed()
        {
            _waveView.HidePanel();
            _signalBus.Fire(new WaveStartedSignal());
        }
    }
}