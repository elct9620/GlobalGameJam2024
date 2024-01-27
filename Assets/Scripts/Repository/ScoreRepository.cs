using System.Collections.Generic;
using Entity;

namespace Repository
{
    public class ScoreRepository
    {
        private readonly Dictionary<PuzzleType, double> _scores = new();
        
        public double Get(PuzzleType type)
        {
            if (!_scores.ContainsKey(type))
            {
                return 0;
            }
            
            return _scores[type];
        }
        
        public void Reset()
        {
            _scores.Clear();
        }

        public void Add(PuzzleType type, double score)
        {
            if (_scores.ContainsKey(type))
            {
                return;
            }
            
            _scores.Add(type, score);
        }
    }
}