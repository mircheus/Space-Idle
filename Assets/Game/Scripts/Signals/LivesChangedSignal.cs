namespace Game.Scripts
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