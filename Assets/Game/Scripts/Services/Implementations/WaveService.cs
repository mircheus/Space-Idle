using Game.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Implementations
{
    public class WaveService : IWaveService, ITickable, IInitializable
    {
        private readonly WavesConfig _wavesConfig;
        private readonly IEnemyService _enemyService;
        private readonly SignalBus _signalBus;
        
        private WaveData _currentWave;
        private int _currentEnemyIndex;
        private float _timer;
        private bool _isWaveActive;

        public WaveService(GameSettings gameSettings, IEnemyService enemyService, SignalBus signalBus)
        {
            Debug.Log($"WaveService constructor");
            _wavesConfig = gameSettings.WavesConfig;
            _enemyService = enemyService;
            _currentEnemyIndex = 0;
            _currentWave = _wavesConfig.Waves[0];
            _signalBus = signalBus;
            _isWaveActive = false;
        }

        public void Initialize()
        {
            Debug.Log($"Initialize");
            StartWave(0);
        }

        public void Tick()
        {
            if (_isWaveActive == false)
                return;
            
            _timer += Time.deltaTime;
            
            if (_timer >= _currentWave.EnemySpawnData.SpawnInterval)
            {
                SpawnNextEnemy();
                _timer = 0;
            }
        }

        public void StartWave(int index)
        {
            _currentWave = _wavesConfig.Waves[index];
            _isWaveActive = true;
            _signalBus.Fire<WaveStartedSignal>();
        }

        public int GetCurrentWave()
        {
            return -1;
        }

        private void SpawnNextEnemy()
        {
            if (_currentEnemyIndex >= _currentWave.EnemySpawnData.Enemies.Length)
            {
                _signalBus.Fire<WaveCompletedSignal>();
                return;
            }

            _enemyService.SpawnEnemy(_currentWave.EnemySpawnData.Enemies[_currentEnemyIndex].Type);
            _currentEnemyIndex++;
        }
    }
}