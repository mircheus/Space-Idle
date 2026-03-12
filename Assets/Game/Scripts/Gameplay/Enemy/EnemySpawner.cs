using System;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        
        private Enemy.Factory _enemyFactory;
        private float _timer;
        private GameSettings _settings;

        [Inject]
        public void Construct(Enemy.Factory enemyFactory, GameSettings settings)
        {
            _enemyFactory = enemyFactory;
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
            enemy.transform.position = spawnPoint.position;
        }
    }
}