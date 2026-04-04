using Game.Scripts;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private int damage = 20;
    [SerializeField] private float maxLifetime = 5f;     // авто-уничтожение
    
    private Vector3 _direction;
    private Rigidbody2D _rb;

    private void Awake() => _rb = GetComponent<Rigidbody2D>();

    /// <summary>Вызывается башней сразу после Instantiate.</summary>
    public void Init(Vector3 direction)
    {
        _direction = direction;
        Destroy(gameObject, maxLifetime);                // фолбэк на случай промаха
    }

    private void FixedUpdate()
    {
        // Наводимся на текущую позицию цели (homing)
        _rb.linearVelocity = _direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<Enemy>(out var enemy)) return;
        enemy.TakeDamage(damage);
        Destroy(gameObject);
    }
    
    public class Pool : MemoryPool<Projectile> {}
}