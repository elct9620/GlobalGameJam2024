using Reflex.Attributes;
using UnityEngine.SceneManagement;
using Score = Repository.Score;

namespace Command
{
    public class Puzzle {
        private readonly Score _score;
        private string _name;
        private double _startAt;

        public Puzzle(Score score)
        {
            _score = score;
        }
        
        public void ResetAll()
        {
            _score.Reset();
        }

        public void Start(double time)
        {
            _startAt = time;
        }

        public void End(double time)
        {
            Scene current = SceneManager.GetActiveScene();
            _score.Add(current.name, time - _startAt);
        }
    }   
}