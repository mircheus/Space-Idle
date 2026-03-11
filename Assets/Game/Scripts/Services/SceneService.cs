using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Project.Services
{
    public class SceneService : ISceneService
    {
        public void LoadGameplay() => SceneManager.LoadScene("Gameplay");
    }
}