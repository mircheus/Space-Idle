using System;
using Zenject;

namespace Game.Scripts.UI
{
    public class HUDPresenter : IInitializable, IDisposable
    {
        private HUDView _hudView;
        private SignalBus _signalBus;
        private int _startLives;
        private int _startGold;
        
        public HUDPresenter(HUDView hudView, SignalBus signalBus, GameSettings settings)
        {
            _hudView = hudView;
            _signalBus = signalBus;
            _startLives = settings.StartLives;
            _startGold = settings.StartGold;
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<GoldChangedSignal>(OnGoldChanged);
            _signalBus.Subscribe<LivesChangedSignal>(OnLivesChanged);
            SetStartValues();
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<GoldChangedSignal>(OnGoldChanged);
            _signalBus.Unsubscribe<LivesChangedSignal>(OnLivesChanged);
        }

        private void SetStartValues()
        {
            _hudView.SetHp(_startLives);
            _hudView.SetGold(_startGold);
        }

        private void OnGoldChanged(GoldChangedSignal gold)
        {
            _hudView.SetGold(gold.NewValue);
        }

        private void OnLivesChanged(LivesChangedSignal lives)
        {
            _hudView.SetHp(lives.NewValue);
        }
    }
}