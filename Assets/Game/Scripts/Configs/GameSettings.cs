using UnityEngine;

namespace Game.Scripts
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Space-Idle/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [Header("Player Settings:")]
        [SerializeField] private int startLives = 3;
    
        [Header("Enemy Settings:")]
        [SerializeField] private EnemiesList enemiesList;

        public EnemiesList EnemiesList => enemiesList;
        public int StartLives => startLives;
    }
}