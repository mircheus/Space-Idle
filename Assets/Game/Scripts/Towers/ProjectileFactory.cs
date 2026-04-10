using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    public class ProjectileFactory
    {
        // private readonly Dictionary<ProjectileType, Projectile.Pool> _pools;
        private readonly Projectile.Pool _projectilePool;
        
        public ProjectileFactory(Projectile.Pool pool)
        {
            _projectilePool = pool;
            // _pools = new Dictionary<ProjectileType, Projectile.Pool>();
        }

        public Projectile Spawn(Vector3 start, Vector3 direction)
        {
            return _projectilePool.Spawn(start, direction);
        }
    }
}