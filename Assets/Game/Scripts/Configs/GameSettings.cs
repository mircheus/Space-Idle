using Game.Scripts.Gameplay.Enemy;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Space-Idle/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private EnemySettings enemySettings;

    public EnemySettings EnemySettings => enemySettings;
}