namespace Game.Scripts.Interfaces
{
    public interface IEconomyService
    {
        int Gold { get; }
        bool TrySpend(int amount);
        void AddGold(int amount);
    }
}