using UnityEngine;

namespace Game.Scripts
{
    [CreateAssetMenu(fileName = "WaveData", menuName = "Space-Idle/WaveData", order = 0)]
    public class WaveData : ScriptableObject
    {
        [SerializeField] private EnemySpawnData enemySpawnData;

        public EnemySpawnData EnemySpawnData => enemySpawnData;
    }
}