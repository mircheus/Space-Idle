using System.Collections.Generic;

namespace Game.Scripts
{
    public class EnemyConfigProvider
    {
        private readonly Dictionary<EnemyType, EnemyConfig> _configs;

        public EnemyConfigProvider(AllEnemiesList allEnemiesList)
        {
            _configs = new Dictionary<EnemyType, EnemyConfig>();

            foreach (var enemyConfig in allEnemiesList.EnemiesConfigs)
            {
                _configs[enemyConfig.Type] = enemyConfig;
            }
        }

        public EnemyConfig GetConfig(EnemyType type)
        {
            return _configs[type];
        }
    }
}