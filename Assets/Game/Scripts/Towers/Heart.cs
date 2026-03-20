using Game.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Scripts
{
    public class Heart : MonoBehaviour
    {
        private IHealthService _healthService;
        private BoxCollider2D _collider;

        [Inject]
        public void Construct(IHealthService healthService)
        {
            _healthService = healthService;
        }
        
        private void Start()
        {
            _collider = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
            {
                _healthService.TakeDamage(enemy.Damage);
            }
        }
    }
}