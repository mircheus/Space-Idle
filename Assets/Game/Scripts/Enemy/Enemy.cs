using System;
using Game.Scripts.Project.Services;
using Game.Scripts.Project.Signals;
using Game.Scripts.Towers;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.Enemy
{
    public class Enemy : MonoBehaviour
    {
        private int _health;
        private float _speed;
        private int _damage;
        private int _pointsPerKill;
        private bool _isDead = false;
        private bool _isReached = false;
        private SignalBus _signalBus;
        private IPathService _pathService;
        private Vector3 _currentWaypoint;
        private EnemySettings _settings;
        private int _currentWaypointIndex = 0;
        
        public int Damage => _damage;

        [Inject]
        public void Construct(GameSettings settings, SignalBus signalBus, IPathService pathService)
        {
            Debug.Log("Enemy Construct");
            _signalBus = signalBus;
            _settings = settings.EnemySettings;
            _pathService = pathService;
        }

        public void Initialize()
        {
            Debug.Log("Enemy Initialize");
            _health = _settings.MaxHealth;
            _speed = _settings.Speed;
            _pointsPerKill =  _settings.PointsPerKill;
            _damage = _settings.Damage;
        }

        private void Start()
        {
            SetNextWaypoint();
        }

        private void Update()
        {
            if (_isDead)
                return;

            if (_isReached)
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Heart heart))
            {
                _isReached = true;
                Destroy(gameObject, 1f);
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