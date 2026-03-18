using System;
using Game.Scripts.Project.Services;
using Game.Scripts.Project.Signals;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.Enemy
{
    public class Enemy : MonoBehaviour
    {
        private int _health;
        private float _speed;
        private int _pointsPerKill;
        private bool _isDead;
        private SignalBus _signalBus;
        private IPathService _pathService;
        private Vector3 _currentWaypoint;
        private int _currentWaypointIndex = 0;

        [Inject]
        public void Construct(GameSettings settings, SignalBus signalBus, IPathService pathService)
        {
            _signalBus = signalBus;
            _health = settings.EnemySettings.MaxHealth;
            _speed = settings.EnemySettings.Speed;
            _pointsPerKill =  settings.EnemySettings.Points;
            _pathService = pathService;
        }

        private void Start()
        {
            SetNextWaypoint();
        }

        private void Update()
        {
            if (_isDead)
                return;
            
            MoveTowardsTarget();
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                _isDead = true;
                _signalBus.Fire(new EnemyDiedSignal(_pointsPerKill));
            }
        }

        private void MoveTowardsTarget()
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint, _speed * Time.deltaTime);

            if (transform.position == _currentWaypoint)
            {
                SetNextWaypoint();
            }
        }

        private void SetNextWaypoint()
        {
            _currentWaypoint = _pathService.GetNextWaypoint(_currentWaypointIndex);
            _currentWaypointIndex++;
        }
        
        public class Factory : PlaceholderFactory<Enemy> { }
    }
}