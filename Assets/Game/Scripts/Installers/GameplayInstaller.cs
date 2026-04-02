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
        [SerializeField] private HUDView hudView;
        [SerializeField] private Camera mainCamera;

        public override void InstallBindings()
        {
            InstallSignals();
            InstallInput();
            InstallTowers();
            InstallEnemies();
            InstallEconomy();
            InstallUI();
            Container.BindInterfacesTo<GameController>().AsSingle();
        }

        private void InstallSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<EnemyDiedSignal>();
            Container.DeclareSignal<EnemyReachedHeartSignal>();
            Container.DeclareSignal<WaveStartedSignal>();
            Container.DeclareSignal<WaveCompletedSignal>();
            Container.DeclareSignal<GameOverSignal>();
            Container.DeclareSignal<LivesChangedSignal>();
            Container.DeclareSignal<GoldChangedSignal>();
        }

        private void InstallTowers()
        {
            Container.Bind<ITowerService>()
                .To<TowerService>()
                .AsSingle();

            Container.BindFactory<TowerType, Tower, Tower.Factory>()
                .FromComponentInNewPrefab(towerPrefab)
                .UnderTransformGroup("Towers");

            Container.BindInterfacesTo<HealthService>()
                .FromNew()
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

            Container.BindInterfacesAndSelfTo<EnemyService>()
                .AsSingle();

            Container.BindInterfacesTo<WaveService>()
                .AsSingle();

            Container.Bind<EnemyConfigProvider>()
                .AsSingle();

            Container.Bind<AllEnemiesList>()
                .FromInstance(allEnemiesList)
                .AsSingle();
        }

        private void InstallEconomy()
        {
            Container.Bind<IEconomyService>()
                .To<EconomyService>()
                .AsSingle();
        }

        private void InstallInput()
        {
            Container.Bind<Camera>()
                .FromInstance(mainCamera);
            
            Container.Bind<IInputService>()
                .To<MouseInput>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<TowerPlacementMediator>()
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
            
            Container.Bind<HUDView>()
                .FromInstance(hudView)
                .AsSingle();
            
            Container.BindInterfacesTo<HUDPresenter>()
                .FromNew()
                .AsSingle();
        }
    }
}