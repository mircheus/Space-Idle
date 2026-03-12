using Game.Scripts.Project.Services;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Project.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private GameObject towerPrefab;
        
		public override void InstallBindings()
        {
            Debug.Log("Installing GameplayInstaller");
            
            Container.Bind<IInputService>()
                .To<MouseInput>()
                .AsSingle();

            Container.Bind<ITowerService>()
                .To<TowerService>()
                .AsSingle();

            Container.BindFactory<TowerType, Tower, Tower.Factory>()
                .FromComponentInNewPrefab(towerPrefab);
        }
    }
}