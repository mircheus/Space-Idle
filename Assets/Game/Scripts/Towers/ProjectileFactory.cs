using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Scripts
{
    public class ProjectileFactory:  IInitializable
    {
        // Словарь пулов по типу башни — каждый пул содержит снаряды
        // с нужным префабом для своего типа башни
        private readonly Dictionary<TowerType, Projectile.Pool> _pools;
        private readonly Projectile.Pool _projectilePool;
        private readonly ProjectileConfig[] _configs;
        private readonly DiContainer _container;

        public ProjectileFactory(DiContainer container, ProjectileConfig[] configs)
        {
            _configs = configs;
            _pools = new Dictionary<TowerType, Projectile.Pool>();
            _container = container;
        }

        // Initialize() вызывается Zenject после того как все биндинги готовы.
        // Именно здесь резолвим пулы — в конструкторе они ещё не готовы
        public void Initialize()
        {
            foreach (var config in _configs)
            {   
                var pool = _container.ResolveId<Projectile.Pool>((object)config.towerType);
                _pools[config.towerType] = pool;
            }
        }

        // Точка входа для башен — башня знает свой TowerType,
        // фабрика выбирает нужный пул и передаёт конфиг при спавне
        public Projectile Spawn(TowerType type, Vector3 start, Vector3 direction)
        {
            var config = GetConfig(type);
            return _pools[type].Spawn(start, direction, config);
        }

        private ProjectileConfig GetConfig(TowerType type)
        {
            foreach (var config in _configs)
            {
                if (config.towerType == type)
                    return config;
            }

            return null;
        }
    }
}