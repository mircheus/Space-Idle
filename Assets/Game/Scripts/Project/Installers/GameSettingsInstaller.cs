using UnityEngine;
using Zenject;

namespace Game.Scripts.Project.Installers
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Space-Idle/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField] private GameSettings gameSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(gameSettings).AsSingle();
        }
    }
}