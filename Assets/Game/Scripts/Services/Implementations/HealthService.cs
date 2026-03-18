using Game.Scripts.Project.Signals;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Project.Services
{
    public class HealthService : IHealthService, IInitializable
    {
        private readonly GameSettings _gameSettings;
        private readonly SignalBus _signalBus;
        private int _lives;
        
        public int Lives => _lives;

        public HealthService(GameSettings gameSettings, SignalBus signalBus)
        {
            _gameSettings = gameSettings;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _lives = _gameSettings.StartLives;
        }

        public void TakeDamage(int amount)
        {
            Debug.Log($"TakeDamage {amount}");
            if(_lives <= 0) return;
            
            _lives = Mathf.Max(0, _lives - amount);
            Debug.Log($"Lives {amount}");
            _signalBus.Fire(new LivesChangedSignal(_lives));
            
            if (_lives <= 0)
            {
                _signalBus.Fire(new GameOverSignal());
            }
        }
    }
}