using UnityEngine;

namespace Game.Scripts
{
    [CreateAssetMenu(fileName = "EnemySpawnData", menuName = "Space-Idle/EnemySpawnData", order = 0)]
    public class EnemySpawnData : ScriptableObject
    {
        [SerializeField] private int enemiesCount;
        [SerializeField] private EnemiesList enemiesList;
        [SerializeField] private float spawnInterval;

        public int EnemiesCount => enemiesCount;
        public EnemiesList EnemiesList => enemiesList;
        public float SpawnInterval => spawnInterval;
    }
}