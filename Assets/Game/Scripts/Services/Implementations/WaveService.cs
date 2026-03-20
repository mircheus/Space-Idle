using Game.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Implementations
{
    public class WaveService : IWaveService, ITickable
    {
        private readonly WaveConfig _waveConfig;
        private readonly IEnemyService _enemyService;
        
        private WaveData _currentWave;

        public WaveService(WaveConfig waveConfig, IEnemyService enemyService)
        {
            _waveConfig = waveConfig;
            _enemyService = enemyService;
        }

        public void Tick()
        {
            
        }
        
        public void StartWave(int index)
        {
            _currentWave = _waveConfig.Waves[index];
        }

        public int GetCurrentWave()
        {
            return -1;
        }
    }
}