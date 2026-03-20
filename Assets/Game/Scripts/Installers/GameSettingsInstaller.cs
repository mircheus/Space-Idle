using UnityEngine;
using Zenject;

namespace Game.Scripts
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Space-Idle/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField] private GameSettings gameSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(gameSettings).AsSingle();
            Container.BindInstance(gameSettings.EnemiesList).AsSingle();
        }
    }
}