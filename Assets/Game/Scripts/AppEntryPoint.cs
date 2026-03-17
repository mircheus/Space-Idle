using Game.Scripts.Project.Services;
using Zenject;

public class AppEntryPoint : IInitializable
{
    // private readonly GameSettings _gameSettings;
    private readonly ISceneService _sceneService;

    public AppEntryPoint(ISceneService sceneService)
    {
        // _gameSettings = gameSettings;
        _sceneService = sceneService;
    }
    
    public void Initialize()
    {
        _sceneService.LoadGameplay();
    }
}