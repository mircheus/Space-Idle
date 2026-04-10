using System.Collections;
using Game.Scripts;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private float _speed = 12f;
    private int _damage = 20;
    private float _maxLifetime = 5f;     // авто-уничтожение

    [Inject] private Pool _pool;
    
    private Vector3 _direction;
    private Rigidbody2D _rb;
    private Coroutine _maxLifetimeCoroutine;

    private void Awake() => _rb = GetComponent<Rigidbody2D>();
    
    /// <summary>Вызывается башней сразу после Instantiate.</summary>
    public void Init(Vector3 start, Vector3 direction, ProjectileConfig config)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = start;
        _direction = direction;
        _speed = config.Speed;
        _damage = config.Damage;
        _maxLifetime = config.MaxLifetime;
        _maxLifetimeCoroutine = StartCoroutine(DisableAfter(_maxLifetime));
    }

    public void Deactivate()
    {
        if (_maxLifetimeCoroutine != null)
        {
            StopCoroutine(_maxLifetimeCoroutine);
        }

        _rb.linearVelocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        // Наводимся на текущую позицию цели (homing)
        _rb.linearVelocity = _direction * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<Enemy>(out var enemy)) return;
        enemy.TakeDamage(_damage);
        DespawnIfActive();
    }

    private IEnumerator DisableAfter(float time)
    {
        yield return new WaitForSeconds(time);
        DespawnIfActive();
    }

    private void DespawnIfActive()
    {
        if(gameObject.activeSelf) _pool.Despawn(this);
    }

    public class Pool : MemoryPool<Vector3, Vector3, Projectile>
    {
        [Inject] private ProjectileConfig _config;
        
        protected override void Reinitialize(Vector3 start, Vector3 direction, Projectile projectile)
        {
            projectile.Init(start, direction, _config);
        }

        protected override void OnDespawned(Projectile projectile)
        {
            projectile.Deactivate();
        }

        protected override void OnCreated(Projectile item)
        {
            base.OnCreated(item);
            item.gameObject.SetActive(false);
        }
    }
}