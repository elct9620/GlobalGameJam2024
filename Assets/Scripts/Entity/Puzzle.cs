namespace Entity
{
    public class Puzzle
    {
        public string Name { get; private set; }
        public double StartAt { get; private set; }
        public double EndAt { get; private set; }
        
        public Puzzle(string name, double time)
        {
            Name = name;
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
    }
}