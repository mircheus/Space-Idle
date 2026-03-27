using System;
using Game.Scripts.Interfaces;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

namespace Game.Scripts.Implementations
{
    public class WaveService : IWaveService, ITickable, IInitializable, IDisposable
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
            _wavesConfig = gameSettings.WavesConfig;
            _enemyService = enemyService;
            _currentEnemyIndex = 0;
            _currentWave = _wavesConfig.Waves[0];
            _signalBus = signalBus;
            _isWaveActive = false;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<EnemyDiedSignal>(CompleteWaveIfNoEnemiesLeft);
            _signalBus.Subscribe<EnemyReachedHeartSignal>(CompleteWaveIfNoEnemiesLeft);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<EnemyDiedSignal>(CompleteWaveIfNoEnemiesLeft);
            _signalBus.Unsubscribe<EnemyReachedHeartSignal>(CompleteWaveIfNoEnemiesLeft);
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
        }

        public int GetCurrentWave()
        {
            return -1;
        }

        private void SpawnNextEnemy()
        {
            if (_currentEnemyIndex >= _currentWave.EnemySpawnData.Enemies.Length)
            {
                // _signalBus.Fire<WaveCompletedSignal>();
                return;
            }

            _enemyService.SpawnEnemy(_currentWave.EnemySpawnData.Enemies[_currentEnemyIndex]);
            _currentEnemyIndex++;
        }

        private void CompleteWaveIfNoEnemiesLeft()
        {
            int activeEnemiesCount = _enemyService.GetActiveEnemiesCount();
            Debug.Log($"Active enemies count: {activeEnemiesCount}");
            
            if (activeEnemiesCount == 0)
            {
                Debug.Log($"[FIRE] WaveCompletedSignal");
                _signalBus.Fire<WaveCompletedSignal>();
            }
        }
    }
}