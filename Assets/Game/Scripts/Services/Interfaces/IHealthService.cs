namespace Game.Scripts.Interfaces
{
    public interface IHealthService
    {
        int Lives { get; }
        void TakeDamage(int amount);
    }
}