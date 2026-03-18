using Game.Scripts.Gameplay.Enemy;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySettings", menuName = "Space-Idle/EnemySettings")]
public class EnemySettings : ScriptableObject
{
    [Header("Enemy Settings")]
    [SerializeField] private int maxHealth;
    [SerializeField] private float speed;
    [SerializeField] private int pointsPerKill;
    [SerializeField] private int damage;


    [Header("Enemy Spawn Settings")] 
    [SerializeField] private float spawnInterval;
    [SerializeField] private int spawnCount;
    
    public int MaxHealth => maxHealth;
    public float Speed => speed;
    public int PointsPerKill => pointsPerKill;
    public float SpawnInterval => spawnInterval;
    public int Damage => damage;
}