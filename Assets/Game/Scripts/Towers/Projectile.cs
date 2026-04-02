using Game.Scripts;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private int damage = 20;
    [SerializeField] private float maxLifetime = 5f;     // авто-уничтожение

    private Enemy _target;
    private Rigidbody _rb;

    private void Awake() => _rb = GetComponent<Rigidbody>();

    /// <summary>Вызывается башней сразу после Instantiate.</summary>
    public void Init(Enemy target)
    {
        _target = target;
        Destroy(gameObject, maxLifetime);                // фолбэк на случай промаха
    }

    private void FixedUpdate()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Наводимся на текущую позицию цели (homing)
        var dir = (_target.transform.position - transform.position).normalized;
        _rb.linearVelocity = dir * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<Enemy>(out var enemy)) return;
        if (enemy != _target) return;                   // игнорируем других врагов

        enemy.TakeDamage(damage);
        Destroy(gameObject);
    }
}