using System;
using System.Collections.Generic;
using Game.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Implementations
{
    public class EnemyService : IEnemyService, IInitializable, IDisposable
    {
        private readonly EnemyFactory _factory;
        private float _timer;
        private readonly Vector3[] _spawnPoints;
        private List<Enemy> _enemies;
        private readonly SignalBus _signalBus;

        public EnemyService(EnemyFactory enemyFactory, LevelPointsConfig levelPointsConfig, SignalBus signalBus)
        {
            _factory = enemyFactory;
            _spawnPoints = levelPointsConfig.SpawnPoints;
            _enemies = new List<Enemy>();
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<EnemyReachedHeartSignal>(EnemyDestroyed);
            _signalBus.Subscribe<EnemyDiedSignal>(EnemyDestroyed);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<EnemyReachedHeartSignal>(EnemyDestroyed);
            _signalBus.Unsubscribe<EnemyDiedSignal>(EnemyDestroyed);
        }

        public Enemy SpawnEnemy(EnemyType type)
        {
            Enemy enemy = _factory.Create(type);
            _enemies.Add(enemy);
            enemy.transform.position = _spawnPoints[0];
            return enemy;
        }

        public List<Enemy> GetActiveEnemies()
        {
            return _enemies;
        }

        public int GetActiveEnemiesCount()
        {
            int activeEnemiesCount = 0;
            
            foreach (var enemy in _enemies)
            {
                if (enemy.IsAlive)
                {
                    activeEnemiesCount++;
                }
            }
            
            return activeEnemiesCount;
        }

        private void EnemyDestroyed()
        {

        }
    }
}