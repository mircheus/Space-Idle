using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    [CreateAssetMenu(fileName = "EnemiesList", menuName = "Space-Idle/EnemiesList")]
    public class EnemiesList : ScriptableObject
    {
        [SerializeField] private List<EnemyConfig> enemiesConfigs;
        
        public List<EnemyConfig> EnemiesConfigs => enemiesConfigs;
    }
}