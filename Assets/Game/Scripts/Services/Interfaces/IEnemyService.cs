using System.Collections.Generic;
using Game.Scripts.Gameplay.Enemy;
using UnityEngine;

namespace Game.Scripts.Project.Services
{
    public interface IEnemyService
    {
        Enemy SpawnEnemy(EnemyType type);
        List<Enemy> GetActiveEnemies();
        void OnEnemyKilled();
        void OnEnemyReachedEnd();
    }
}