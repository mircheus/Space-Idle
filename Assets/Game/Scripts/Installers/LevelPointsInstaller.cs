using Game.Scripts.Gameplay.Enemy;
using Game.Scripts.Project.Settings;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Project.Installers
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