using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Game.Scripts
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Space-Idle/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private WavesConfig wavesConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(gameSettings).AsSingle();
            Container.BindInstance(wavesConfig).AsSingle();
        }
    }
}