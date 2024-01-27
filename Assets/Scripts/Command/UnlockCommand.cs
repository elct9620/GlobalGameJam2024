using Entity;
using Repository;

namespace Command
{
    public class UnlockCommand
    {
        private readonly GameRepository _gameRepository;
        private readonly ScoreRepository _scoreRepository;
        
        public UnlockCommand(GameRepository gameRepository, ScoreRepository scoreRepository)
        {
            _gameRepository = gameRepository;
        }

        public bool Unlock(LockType type, double time)
        {
            Puzzle currentPuzzle = _gameRepository.CurrentPuzzle;
            if (currentPuzzle == null)
            {
                return false;
            }
            
            currentPuzzle.Unlock(type);

            if (currentPuzzle.Resolved())
            {
                double deltaTime = _gameRepository.DeltaTime(time);        
                _scoreRepository.Add(currentPuzzle.type, deltaTime);
                _gameRepository.Reset();
                return true;
            }

            return false;
        }

    }
}