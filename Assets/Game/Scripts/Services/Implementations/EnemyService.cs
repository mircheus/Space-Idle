using System.Collections.Generic;
using Game.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Implementations
{
    public class EnemyService : IEnemyService
    {
        private EnemyFactory _factory;
        private float _timer;
        // private EnemiesList _enemiesList;
        private Vector3[] _spawnPoints;
        private List<Enemy> _enemies;

        public EnemyService(EnemyFactory enemyFactory, LevelPointsConfig levelPointsConfig)
        {
            _factory = enemyFactory;
            // _enemiesList = enemiesList;
            _spawnPoints = levelPointsConfig.SpawnPoints;
            _enemies = new List<Enemy>();
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

        public void OnEnemyKilled()
        {
            
        }

        public void OnEnemyReachedEnd()
        {

        }
    }
}