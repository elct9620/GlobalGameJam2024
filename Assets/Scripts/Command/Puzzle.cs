using System;
using Entity;
using Repository;
using Score = Repository.Score;

namespace Command
{
    public class PuzzleStartError : Exception
    {
        
    }
    
    public class Puzzle {
        private readonly Score _score;
        private readonly Repository.Puzzle _puzzle;
        private readonly Game _game;

        public Puzzle(Game game, Score score)
        {
            _game = game;
            _score = score;
        }

        public Entity.Puzzle Current()
        {
            return _game.CurrentPuzzle;
        }
        
        public void ResetAll()
        {
            _score.Reset();
        }

        public void Start(PuzzleType type, double time)
        {
            if (_game.CurrentPuzzle != null)
            {
                throw new PuzzleStartError();
            }
            
            
            Entity.Puzzle puzzle = _puzzle.Find(type);
            _game.SetPuzzle(puzzle);
        }

        public void End(PuzzleType type, double time)
        {
            Entity.Puzzle puzzle = _game.CurrentPuzzle;
            if (puzzle == null)
            {
                return;
            }
            
            if (puzzle.type != type)
            {
                return;
            }
            
            double delta = time - _game.CurrentPuzzleStartTime;
            _score.Add(puzzle.type, delta);
            _game.SetPuzzle(null);
        }
    }   
}