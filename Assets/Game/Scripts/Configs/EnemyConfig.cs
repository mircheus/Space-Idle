using UnityEngine;

namespace Game.Scripts
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "Space-Idle/EnemySettings")]
    public class EnemyConfig : ScriptableObject
    {
        [Header("Enemy Settings")] 
        [SerializeField] private EnemyType type;
        [SerializeField] private int maxHealth;
        [SerializeField] private float speed;
        [SerializeField] private int pointsPerKill;
        [SerializeField] private int damage;
    
        [Header("Enemy Spawn Settings")] 
        [SerializeField] private float spawnInterval;
        [SerializeField] private int spawnCount;
    
        public EnemyType  Type => type;
        public int MaxHealth => maxHealth;
        public float Speed => speed;
        public int PointsPerKill => pointsPerKill;
        public float SpawnInterval => spawnInterval;
        public int Damage => damage;
    }
}