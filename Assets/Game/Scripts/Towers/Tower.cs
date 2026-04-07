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
        [SerializeField] private Projectile projectilePrefab;
        [SerializeField] private float fireRate;
        [SerializeField] private List<Enemy> _enemiesInRange = new List<Enemy>(); 
        
        private TowerType _towerType; 
        private Collider2D _collider2D;
        private Coroutine _fireCoroutine;
        private Enemy  _currentTarget;
        

        [Inject]
        public void Construct(TowerType towerType)
        {
            _towerType = towerType;
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
                _enemiesInRange.Add(enemy);
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

                if (_enemiesInRange.Contains(enemy))
                    _enemiesInRange.Remove(enemy);
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
            var go = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            if (go.TryGetComponent<Projectile>(out var projectile))
            {
                var direction = (_currentTarget.transform.position - firePoint.position).normalized;
                // projectile.Init(direction);
            }
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