using Entity;
using Reflex.Attributes;
using Repository;

namespace Command
{
    public class PuzzleCommand
    {
        private readonly PuzzleRepository _puzzleRepository;
        private readonly GameRepository _gameRepository;
        
        public PuzzleCommand(PuzzleRepository puzzleRepository, GameRepository gameRepository)
        {
            _puzzleRepository = puzzleRepository;
            _gameRepository = gameRepository;
        }
        
        public void Start(PuzzleType type, double time)
        {
           if(_gameRepository.CurrentPuzzle != null)
           {
               return;
           } 
            
           Puzzle puzzle = _puzzleRepository.Find(type);
           _gameRepository.SetPuzzle(puzzle, time);
        }

        public double DeltaTime(double current)
        {
           if (_gameRepository.CurrentPuzzle == null)
           {
               return 0;
           } 
           
           return current - _gameRepository.CurrentPuzzleStartTime;
        }
    }
}