using UnityEngine;

namespace Game.Scripts.Project.Settings
{
    [CreateAssetMenu(fileName = "LevelPointsConfig", menuName = "Space-Idle/LevelPointsConfig")]
    public class LevelPointsConfig : ScriptableObject
    {
        public Vector3[] SpawnPoints;
        public Vector3[] WayPoints;
    }
}