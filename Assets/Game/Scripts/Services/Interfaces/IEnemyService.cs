using System.Collections.Generic;

namespace Game.Scripts.Interfaces
{
    public interface IEnemyService
    {
        Enemy SpawnEnemy(EnemyType type);
        List<Enemy> GetActiveEnemies();
        void OnEnemyKilled(); // NOTE: вместо метода должен быть Signal
        void OnEnemyReachedEnd(); // NOTE: вместо метода должен быть Signal
    }
}