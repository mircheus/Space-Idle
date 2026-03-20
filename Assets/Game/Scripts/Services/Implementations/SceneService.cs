using Game.Scripts.Interfaces;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Implementations
{
    public class SceneService : ISceneService
    {
        public void LoadGameplay() => SceneManager.LoadScene("Gameplay");
    }
}