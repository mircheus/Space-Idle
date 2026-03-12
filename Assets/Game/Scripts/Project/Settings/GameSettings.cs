using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Space-Idle/GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Enemy Settings")]
    [SerializeField] private int maxHealth;
    [SerializeField] private float speed;
    [SerializeField] private int points;

    [Header("Enemy Spawn Settings")] 
    [SerializeField] private float spawnInterval;
    
    public int MaxHealth => maxHealth;
    public float Speed => speed;
    public int Points => points;
    public float SpawnInterval => spawnInterval;
}