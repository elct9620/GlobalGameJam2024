using System.Collections.Generic;

namespace Repository
{
    public class Score
    {
        private readonly Dictionary<string, double> _scores = new();
        
        public double Get(string name)
        {
            return _scores[name];
        }

        public void Add(string name, double score)
        {
            _scores.Add(name, score);
        }
    }
}