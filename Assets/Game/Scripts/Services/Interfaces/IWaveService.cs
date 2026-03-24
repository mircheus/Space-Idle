namespace Game.Scripts.Interfaces
{
    public interface IWaveService
    {
        void StartWave(int index);
        int GetCurrentWave();
    }
}