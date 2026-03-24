using System;
using Game.Scripts.Interfaces;
using Zenject;

namespace Game.Scripts
{
    public class GameController : IInitializable, IDisposable
    {
        private readonly IWaveService _waveService;
        private readonly IHealthService _healthService;
        private readonly SignalBus _signalBus;

        public GameController(IWaveService waveService, IHealthService healthService, SignalBus signalBus)
        {
            _waveService = waveService;
            _healthService = healthService;
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            _waveService.StartWave(0);
        }

        public void Dispose()
        {
            
        }
    }
}