using System;
using Game.Scripts.Project.Installers;
using Game.Scripts.Project.Settings;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        private Enemy.Factory _enemyFactory;
        private float _timer;
        private EnemySettings _settings;
        private Vector3[] _spawnPoints;

        [Inject]
        public void Construct(Enemy.Factory enemyFactory, EnemySettings settings, LevelPointsConfig levelPointsConfig)
        {
            _enemyFactory = enemyFactory;
            _settings = settings;
            _spawnPoints = levelPointsConfig.SpawnPoints;
        }
        
        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _settings.SpawnInterval)
            {
                Spawn();
                _timer = 0;
            }
        }

        private void Spawn()
        {
            int randomIndex = UnityEngine.Random.Range(0, _spawnPoints.Length);
            var spawnPoint = _spawnPoints[randomIndex];
            Enemy enemy = _enemyFactory.Create();
            enemy.transform.position = spawnPoint;
        }
    }
}