namespace Game.Scripts.Project.Signals
{
    public struct LivesChangedSignal
    {
        public int NewValue;
        
        public LivesChangedSignal(int newValue)
        {
            NewValue = newValue;
        }
    }
}