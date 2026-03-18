using System.Collections.Generic;
using Game.Scripts.Gameplay.Enemy;
using Game.Scripts.Project.Settings;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Project.Services
{
    public class EnemyService : IEnemyService, ITickable
    {
        private Enemy.Factory _factory;
        private float _timer;
        private EnemySettings _settings;
        private Vector3[] _spawnPoints;
        private List<Enemy> _enemies;

        public EnemyService(Enemy.Factory enemyFactory, EnemySettings settings, LevelPointsConfig levelPointsConfig)
        {
            Debug.Log("Created EnemyService");
            _factory = enemyFactory;
            _settings = settings;
            _spawnPoints = levelPointsConfig.SpawnPoints;
            _enemies = new List<Enemy>();
        }

        public void Tick()
        {
            _timer += Time.deltaTime;
            
            if (_timer >= _settings.SpawnInterval)
            {
                SpawnEnemy();
                _timer = 0;
            }
        }

        public Enemy SpawnEnemy(EnemyType type = EnemyType.BasicEnemy)
        {
            Debug.Log("SpawnEnemy");
            // TODO : Добавить логику выбора типа противника
            Enemy enemy = _factory.Create();
            enemy.Initialize();
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