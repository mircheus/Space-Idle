namespace Game.Scripts
{
    public struct GoldChangedSignal
    {
        public int NewValue;
        
        public GoldChangedSignal(int newValue)
        {
            NewValue = newValue;
        }
    }
}