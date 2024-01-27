using System;
using Entity;
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

        public void Start(PuzzleType type, double time)
        {
            if (_game.CurrentPuzzle != null)
            {
                throw new PuzzleStartError();
            }
            
            Entity.Puzzle puzzle = new Entity.Puzzle(type, time);
            _game.SetPuzzle(puzzle);
        }

        public void End(PuzzleType type, double time)
        {
            Entity.Puzzle puzzle = _game.CurrentPuzzle;
            if (puzzle == null)
            {
                return;
            }
            
            if (puzzle.Type != type)
            {
                return;
            }
            
            puzzle.End(time);
            _score.Add(puzzle.Type, puzzle.Delta());
            _game.SetPuzzle(null);
        }
    }   
}