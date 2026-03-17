namespace Game.Scripts.Project.Signals
{
    public struct EnemyDiedSignal
    {
        public int Points { get; }

        public EnemyDiedSignal(int points)
        {
            Points = points;
        }
    }
}