using Game.Scripts.Implementations;
using Game.Scripts.Interfaces;
using Game.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Game.Scripts
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private GameObject towerPrefab;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private AllEnemiesList allEnemiesList;
        [SerializeField] private WaveView waveView;

        public override void InstallBindings()
        {
            InstallSignals();
            InstallInput();
            InstallTowers();
            InstallEnemies();
            InstallUI();
            Container.BindInterfacesTo<GameController>().AsSingle();
        }

        private void InstallSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<EnemyDiedSignal>();
            Container.DeclareSignal<WaveStartedSignal>();
            Container.DeclareSignal<WaveCompletedSignal>();
        }

        private void InstallTowers()
        {
            Container.Bind<ITowerService>()
                .To<TowerService>()
                .AsSingle();

            Container.BindFactory<TowerType, Tower, Tower.Factory>()
                .FromComponentInNewPrefab(towerPrefab)
                .UnderTransformGroup("Towers");

            Container.Bind<IHealthService>()
                .To<HealthService>()
                .AsSingle();
        }

        private void InstallEnemies()
        {
            Container.BindFactory<EnemyType, Enemy, EnemyFactory>()
                .FromComponentInNewPrefab(enemyPrefab)
                .AsSingle();

            Container.Bind<IPathService>()
                .To<PathService>()
                .AsSingle();
            
            Container.Bind<IEnemyService>()
                .To<EnemyService>()
                .AsSingle();

            Container.BindInterfacesTo<WaveService>()
                .AsSingle();

            Container.Bind<EnemyConfigProvider>()
                .AsSingle();

            Container.Bind<AllEnemiesList>()
                .FromInstance(allEnemiesList)
                .AsSingle();
        }

        private void InstallInput()
        {
            Container.Bind<IInputService>()
                .To<MouseInput>()
                .AsSingle();
        }
        
        private void InstallUI()
        {
            Container.Bind<WaveView>()
                .FromInstance(waveView)
                .AsSingle();
            
            Container.BindInterfacesTo<WavePresenter>()
                .FromNew()
                .AsSingle();
        }
    }
}