using System;
using Game.Scripts.Project.Signals;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.Enemy
{
    public class Enemy : MonoBehaviour
    {
        private Transform _target;
        private int _health;
        private float _speed;
        private int _pointsPerKill;
        private bool _isDead;
        private SignalBus _signalBus;

        [Inject]
        public void Construct(Transform t, GameSettings settings, SignalBus signalBus)
        {
            _target = t;
            _signalBus = signalBus;
            _health = settings.MaxHealth;
            _speed = settings.Speed;
            _pointsPerKill =  settings.Points;
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
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }
        
        public class Factory : PlaceholderFactory<Enemy> { }
    }
}