using System.Collections.Generic;

namespace Repository
{
    public class Score
    {
        private readonly Dictionary<string, double> _scores = new();
        
        public double Get(string name)
        {
            if (!_scores.ContainsKey(name))
            {
                return 0;
            }
            
            return _scores[name];
        }
        
        public void Reset()
        {
            _scores.Clear();
        }

        public void Add(string name, double score)
        {
            if (_scores.ContainsKey(name))
            {
                return;
            }
            
            _scores.Add(name, score);
        }
    }
}