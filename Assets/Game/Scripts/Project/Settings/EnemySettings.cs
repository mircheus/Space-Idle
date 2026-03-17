using Game.Scripts.Gameplay.Enemy;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySettings", menuName = "Space-Idle/EnemySettings")]
public class EnemySettings : ScriptableObject
{
    [Header("Enemy Settings")]
    [SerializeField] private int maxHealth;
    [SerializeField] private float speed;
    [SerializeField] private int points;

    [Header("Enemy Spawn Settings")] 
    [SerializeField] private float spawnInterval;
    [SerializeField] private int spawnCount;
    // [SerializeField] private SpawnPoints spawnPoints;
    
    public int MaxHealth => maxHealth;
    public float Speed => speed;
    public int Points => points;
    public float SpawnInterval => spawnInterval;
    // public SpawnPoints SpawnPoints => spawnPoints;
}