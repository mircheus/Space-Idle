using UnityEngine;
using Zenject;

namespace Game.Scripts
{
    public class LevelPointsInstaller : MonoInstaller
    {
        [SerializeField] private LevelPointsConfig levelPointsConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(levelPointsConfig).AsSingle();
        }
    }
}