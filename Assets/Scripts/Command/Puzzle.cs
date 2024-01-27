using System;
using Reflex.Attributes;
using Repository;
using UnityEngine.SceneManagement;
using Score = Repository.Score;

namespace Command
{
    public class PuzzleStartError : Exception
    {
        
    }
    public class Puzzle {
        private readonly Score _score;
        private readonly Game _game;

        public Puzzle(Game game, Score score)
        {
            _game = game;
            _score = score;
        }
        
        public void ResetAll()
        {
            _score.Reset();
        }

        public void Start(string name, double time)
        {
            if (_game.CurrentPuzzle != null)
            {
                throw new PuzzleStartError();
            }
            
            Entity.Puzzle puzzle = new Entity.Puzzle(name, time);
            _game.SetPuzzle(puzzle);
        }

        public void End(double time)
        {
            Entity.Puzzle puzzle = _game.CurrentPuzzle;
            if (puzzle != null)
            {
                puzzle.End(time);
                _score.Add(puzzle.Name, puzzle.Delta());
            }
            
            _game.SetPuzzle(null);
        }
    }   
}