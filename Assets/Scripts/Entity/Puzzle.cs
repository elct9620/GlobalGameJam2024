namespace Entity
{
    public class Puzzle
    {
        public PuzzleType Type { get; private set; }
        public double StartAt { get; private set; }
        public double EndAt { get; private set; }
        
        public Puzzle(PuzzleType type, double time)
        {
            Type = type;
            StartAt = time;
        }
        
        public void End(double time)
        {
            EndAt = time;
        }
        
        public double Delta()
        {
            return EndAt - StartAt;
        }
        
        public double Delta(double time)
        {
            return time - StartAt;
        }
    }
}