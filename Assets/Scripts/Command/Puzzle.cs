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

        public Entity.Puzzle Current()
        {
            return _game.CurrentPuzzle; 
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

        public void End(string name, double time)
        {
            Entity.Puzzle puzzle = _game.CurrentPuzzle;
            if (puzzle == null)
            {
                return;
            }
            
            if (puzzle.Name != name)
            {
                return;
            }
            
            puzzle.End(time);
            _score.Add(puzzle.Name, puzzle.Delta());
            _game.SetPuzzle(null);
        }
    }   
}