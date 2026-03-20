using Game.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Scripts
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
        private EnemyConfig _config;
        private int _currentWaypointIndex = 0;
        
        public int Damage => _damage;

        [Inject]
        public void Construct(SignalBus signalBus, IPathService pathService)
        {
            Debug.Log("Enemy Construct");
            _signalBus = signalBus;
            // _config = config;
            _pathService = pathService;
        }

        public void Initialize()
        {
            Debug.Log("Enemy Initialize");
            _health = _config.MaxHealth;
            _speed = _config.Speed;
            _pointsPerKill =  _config.PointsPerKill;
            _damage = _config.Damage;
        }

        public void Setup(EnemyConfig config)
        {
            Debug.Log("Enemy Setup");
            _health = config.MaxHealth;
            _speed = config.Speed;
            _pointsPerKill =  config.PointsPerKill;
            _damage = config.Damage;
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

        public class Factory : PlaceholderFactory<EnemyType, Enemy> { }
    }
}