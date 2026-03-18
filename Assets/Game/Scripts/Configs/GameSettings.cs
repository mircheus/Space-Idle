using Game.Scripts.Gameplay.Enemy;
using Game.Scripts.Project.Services;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Space-Idle/GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Player Settings:")]
    [SerializeField] private int startLives = 3;
    
    [Header("Enemy Settings:")]
    [SerializeField] private EnemySettings enemySettings;

    public EnemySettings EnemySettings => enemySettings;
    public int StartLives => startLives;
}