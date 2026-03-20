using UnityEngine;

namespace Game.Scripts
{
    [CreateAssetMenu(fileName = "WaveConfig", menuName = "Space-Idle/WaveConfig", order = 0)]
    public class WaveConfig : ScriptableObject
    {
        [SerializeField] private WaveData[] waves;

        public WaveData[] Waves => waves;
    }
}