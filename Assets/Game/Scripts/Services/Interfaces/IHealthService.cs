namespace Game.Scripts.Project.Services
{
    public interface IHealthService
    {
        int Lives { get; }
        void TakeDamage(int amount);
    }
}