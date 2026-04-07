using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    public class ProjectileFactory
    {
        private readonly Dictionary<ProjectileType, Projectile.Pool> _pools;

        public ProjectileFactory()
        {
            _pools = new Dictionary<ProjectileType, Projectile.Pool>();
        }

        public Projectile Spawn(ProjectileType type, Vector3 direction, ProjectileConfig config)
        {
            return _pools[type].Spawn(direction, config);
        }
    }
}