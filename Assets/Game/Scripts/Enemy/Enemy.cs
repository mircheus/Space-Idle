using Game.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        private int _health;
        private float _speed;
        private int _damage;
        private int _pointsPerKill;
        private bool _isReached = false;
        private SignalBus _signalBus;
        private IPathService _pathService;
        private Vector3 _currentWaypoint;
        private EnemyConfig _config;
        private int _currentWaypointIndex = 0;
        private EnemyType _type;
        private bool _isAlive = true;

        public int Damage => _damage;
        public bool IsAlive => _isAlive;

        [Inject]
        public void Construct(EnemyType type, SignalBus signalBus, IPathService pathService)
        {
            _type = type;
            _signalBus = signalBus;
            // _config = config;
            _pathService = pathService;
        }

        public void Setup(EnemyConfig config)
        {
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
            if (_isAlive == false)
                return;

            if (_isReached)
                return;
            
            MoveTowardsTarget();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Heart heart))
            {
                _isReached = true;
                _isAlive = false;
                _signalBus.Fire(new EnemyReachedHeartSignal());
                Destroy(gameObject);
            }
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                _isAlive = false;
                spriteRenderer.enabled = false;
                _signalBus.Fire(new EnemyDiedSignal(_pointsPerKill));
                Destroy(gameObject);
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
    }
}