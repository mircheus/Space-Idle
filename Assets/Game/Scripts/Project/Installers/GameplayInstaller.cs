using Game.Scripts.Project.Services;
using Game.Scripts.Project.Signals;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Project.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private GameObject towerPrefab;
        
		public override void InstallBindings()
        {
           InstallSignals();
           InstallInput();
           InstallTowers();
        }

        private void InstallSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<EnemyDiedSignal>();
        }

        private void InstallTowers()
        {
            Container.Bind<ITowerService>()
                .To<TowerService>()
                .AsSingle();

            Container.BindFactory<TowerType, Tower, Tower.Factory>()
                .FromComponentInNewPrefab(towerPrefab)
                .UnderTransformGroup("Towers");
        }

        private void InstallInput()
        {
            Container.Bind<IInputService>()
                .To<MouseInput>()
                .AsSingle();
        }
    }
}