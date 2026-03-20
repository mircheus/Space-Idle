using Game.Scripts.Implementations;
using Game.Scripts.Interfaces;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<AppEntryPoint>().AsSingle();
        
        Container.Bind<ISceneService>()
            .To<SceneService>()
            .AsSingle();
    }
}