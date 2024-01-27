using Entity;
using Event;
using Repository;

namespace Command
{
    public class UnlockCommand
    {
        private readonly GameRepository _gameRepository;
        private readonly ScoreRepository _scoreRepository;
        private readonly GameEvent<UnlockEvent> _unlockEvent;
        private readonly GameEvent<ResolveEvent> _resolveEvent;

        public UnlockCommand(
            GameRepository gameRepository,
            ScoreRepository scoreRepository,
            GameEvent<UnlockEvent> unlockEvent,
            GameEvent<ResolveEvent> resolveEvent
        )
        {
            _gameRepository = gameRepository;
            _scoreRepository = scoreRepository;
            _unlockEvent = unlockEvent;
            _resolveEvent = resolveEvent;
        }

        public bool Unlock(LockType type, double time)
        {
            Puzzle currentPuzzle = _gameRepository.CurrentPuzzle;
            if (currentPuzzle == null)
            {
                return false;
            }

            bool isUnlocked = currentPuzzle.Unlock(type);
            if (isUnlocked)
            {
                _unlockEvent.Emit(new UnlockEvent(type));
            }

            if (currentPuzzle.Resolved())
            {
                double deltaTime = _gameRepository.DeltaTime(time);
                _scoreRepository.Add(currentPuzzle.type, deltaTime);
                _gameRepository.Reset();
                _resolveEvent.Emit(new ResolveEvent(currentPuzzle.type));
                return true;
            }

            return false;
        }
    }
}