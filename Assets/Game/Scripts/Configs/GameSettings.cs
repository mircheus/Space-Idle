using UnityEngine;

namespace Game.Scripts
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Space-Idle/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [Header("Player Settings:")]
        [SerializeField] private int startLives = 3;
        [SerializeField] private LayerMask buildZoneLayer;
        
        [Header("Wave Settings:")]
        [SerializeField] private WavesConfig wavesConfig;
    
        public int StartLives => startLives;
        public LayerMask BuildZoneLayer => buildZoneLayer;
        
        public WavesConfig WavesConfig => wavesConfig;
    }
}   