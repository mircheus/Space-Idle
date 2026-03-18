using System.Collections.Generic;
using Game.Scripts.Gameplay.Enemy;
using UnityEngine;

namespace Game.Scripts.Project.Services
{
    public interface IEnemyService
    {
        Enemy SpawnEnemy(EnemyType type);
        List<Enemy> GetActiveEnemies();
        void OnEnemyKilled(); // NOTE: вместо метода должен быть Signal
        void OnEnemyReachedEnd(); // NOTE: вместо метода должен быть Signal
    }
}