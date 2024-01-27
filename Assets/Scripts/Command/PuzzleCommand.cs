using System;
using Entity;
using Repository;

namespace Command
{
    public class PuzzleStartError : Exception
    {
        
    }
    
    public class PuzzleCommand {
        private readonly ScoreRepository _scoreRepository;
        private readonly PuzzleRepository _puzzle;
        private readonly GameRepository _gameRepository;

        public PuzzleCommand(GameRepository gameRepository, ScoreRepository scoreRepository)
        {
            _gameRepository = gameRepository;
            _scoreRepository = scoreRepository;
        }

        public Entity.Puzzle Current()
        {
            return _gameRepository.CurrentPuzzle;
        }
        
        public void ResetAll()
        {
            _scoreRepository.Reset();
        }

        public void Start(PuzzleType type, double time)
        {
            if (_gameRepository.CurrentPuzzle != null)
            {
                throw new PuzzleStartError();
            }
            
            
            Entity.Puzzle puzzle = _puzzle.Find(type);
            _gameRepository.SetPuzzle(puzzle);
        }

        public void End(PuzzleType type, double time)
        {
            Entity.Puzzle puzzle = _gameRepository.CurrentPuzzle;
            if (puzzle == null)
            {
                return;
            }
            
            if (puzzle.type != type)
            {
                return;
            }
            
            double delta = time - _gameRepository.CurrentPuzzleStartTime;
            _scoreRepository.Add(puzzle.type, delta);
            _gameRepository.SetPuzzle(null);
        }
    }   
}