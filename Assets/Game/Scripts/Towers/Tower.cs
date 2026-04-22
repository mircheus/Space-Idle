using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Game.Scripts
{
    public class Tower : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private Transform firePoint;
        
        [Header("Inject this instead")]
        [SerializeField] private float fireRate;
        [SerializeField] private List<Enemy> enemiesInRange = new List<Enemy>(); 
        
        private TowerType _towerType; 
        private Collider2D _collider2D;
        private Coroutine _fireCoroutine;
        private Enemy  _currentTarget;
        private ProjectileFactory _projectileFactory;


        [Inject]
        public void Construct(TowerType towerType, ProjectileFactory projectileFactory)
        {
            _towerType = towerType;
            _projectileFactory = projectileFactory;
        }

        private void Awake()
        {
            _collider2D = GetComponent<Collider2D>();
            _collider2D.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Enemy>(out var enemy))
            {
                enemiesInRange.Add(enemy);
            }
            
            if (_currentTarget != null) return;          // уже есть цель
            
            SetTarget(enemy);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<Enemy>(out var enemy))
            {
                if(_currentTarget == enemy)
                    ClearTarget();

                if (enemiesInRange.Contains(enemy))
                    enemiesInRange.Remove(enemy);
            }
        }

        private void SetTarget(Enemy enemy)
        {
            _currentTarget = enemy;

            if (_fireCoroutine != null)
            {
                StopCoroutine(_fireCoroutine);
            }
            
            _fireCoroutine = StartCoroutine(FireLoop());
        }

        private void ClearTarget()
        {
            _currentTarget = null;

            if (_fireCoroutine != null)
            {
                StopCoroutine(_fireCoroutine);
                _fireCoroutine = null;
            }
        }

        private void Shoot()
        {
            var direction = (_currentTarget.transform.position - firePoint.position).normalized;
            _projectileFactory.Spawn(_towerType, firePoint.position, direction);
        }
        
        private IEnumerator FireLoop()
        {
            if (_currentTarget != null && _currentTarget.IsAlive == false)
            {
                ClearTarget();
                yield break;
            }
            
            var interval = new WaitForSeconds(1f / fireRate);

            while (_currentTarget != null)
            {
                Shoot();
                yield return interval;
            }
        }
        
        public class Factory : PlaceholderFactory<TowerType, Tower> { }
    }
}