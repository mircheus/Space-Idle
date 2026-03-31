using System;
using Game.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Scripts
{
    public class GameController : IInitializable, IDisposable
    {
        private readonly IWaveService _waveService;
        private readonly IHealthService _healthService;
        private readonly SignalBus _signalBus;

        private int _currentWave = 0;

        public GameController(IWaveService waveService, IHealthService healthService, SignalBus signalBus)
        {
            _waveService = waveService;
            _healthService = healthService;
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<WaveStartedSignal>(OnWaveStarted);
            _signalBus.Subscribe<GameOverSignal>(OnGameOver);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<WaveStartedSignal>(OnWaveStarted);
            _signalBus.Unsubscribe<GameOverSignal>(OnGameOver);
        }

        private void OnWaveStarted()
        {
            _waveService.StartWave(_currentWave);
        }

        private void OnGameOver()
        {
            // ????
        }
    }
}