using UnityEngine;

namespace Game.Scripts
{
    [CreateAssetMenu(fileName = "EnemySpawnData", menuName = "Space-Idle/EnemySpawnData", order = 0)]
    public class EnemySpawnData : ScriptableObject
    {
        [SerializeField] private EnemyType[] enemies;
        [SerializeField] private float spawnInterval;
        
        public EnemyType[] Enemies => enemies;
        public float SpawnInterval => spawnInterval;
    }
}