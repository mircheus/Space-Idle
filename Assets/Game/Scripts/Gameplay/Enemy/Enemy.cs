using System;
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

        [Inject]
        public void Construct(GameSettings settings, SignalBus signalBus)
        {
            _signalBus = signalBus;
            _health = settings.EnemySettings.MaxHealth;
            _speed = settings.EnemySettings.Speed;
            _pointsPerKill =  settings.EnemySettings.Points;
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
            // transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
            
            transform.Translate(Vector3.left * _speed * Time.deltaTime);

            if (transform.position.x < -6f)
            {
                Destroy(gameObject);
            }
        }
        
        public class Factory : PlaceholderFactory<Enemy> { }
    }
}