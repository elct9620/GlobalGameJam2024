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
        
        public PuzzleType CurrentPuzzle()
        {
           if (_gameRepository.CurrentPuzzle == null)
           {
               return PuzzleType.None;
           }

           return _gameRepository.CurrentPuzzle.type;
        }

        public double DeltaTime(double current)
        {
           return _gameRepository.DeltaTime(current);
        }
    }
}