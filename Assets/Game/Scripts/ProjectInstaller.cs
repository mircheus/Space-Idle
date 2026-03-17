using Game.Scripts.Project.Services;
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