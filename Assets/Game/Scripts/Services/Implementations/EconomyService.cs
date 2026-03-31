using Game.Scripts.Interfaces;
using Zenject;

namespace Game.Scripts.Implementations
{
    public class EconomyService : IEconomyService
    {
        private readonly SignalBus _signalBus;

        private int _gold;
        
        public int Gold => _gold;

        public EconomyService(SignalBus signalBus, GameSettings settings)
        {
            _signalBus = signalBus;
            _gold = settings.StartGold;
        }
        
        public bool TrySpend(int amount)
        {
            if (_gold - amount < 0)
            {
                return false;
            }
            
            _gold -= amount;
            _signalBus.Fire(new GoldChanged(_gold));
            return true;
        }

        public void AddGold(int amount)
        {
            _gold += amount;
            _signalBus.Fire(new GoldChanged(_gold));
        }
    }
}