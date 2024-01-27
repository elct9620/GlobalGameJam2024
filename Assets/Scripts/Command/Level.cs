using Reflex.Attributes;
using Score = Repository.Score;

namespace Command
{
    public class Level {
        private readonly Score _score;
        private string _name;
        private double _startAt;

        public Level(Score score)
        {
            _score = score;
        }

        public void Start(string name, double time)
        {
            _name = name;
            _startAt = time;
        }

        public void End(double time)
        {
            _score.Add(_name, time - _startAt);
        }
    }   
}