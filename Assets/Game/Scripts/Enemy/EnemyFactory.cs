using Zenject;

namespace Game.Scripts
{
    public class EnemyFactory : PlaceholderFactory<EnemyType, Enemy>
    {
        private readonly EnemyConfigProvider _configProvider;

        public EnemyFactory(EnemyConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }

        public override Enemy Create(EnemyType type)
        {
            var enemy = base.Create(type);
            var config = _configProvider.GetConfig(type);
            enemy.Setup(config);
            return enemy;
        }
    }
}