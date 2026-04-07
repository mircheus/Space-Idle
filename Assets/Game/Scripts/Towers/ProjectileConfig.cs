using UnityEngine;

namespace Game.Scripts
{
    [CreateAssetMenu(fileName = "ProjectileConfig", menuName = "Configs/Projectile", order = 0)]
    public class ProjectileConfig : ScriptableObject
    {
        public ProjectileType Type;
        public float Speed;
        public int Damage;
        public float MaxLifetime;
        public GameObject Prefab;
    }
}