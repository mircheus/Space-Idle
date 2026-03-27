using System.Collections.Generic;

namespace Game.Scripts.Interfaces
{
    public interface IEnemyService
    {
        Enemy SpawnEnemy(EnemyType type);
        List<Enemy> GetActiveEnemies();
        int GetActiveEnemiesCount();
    }
}