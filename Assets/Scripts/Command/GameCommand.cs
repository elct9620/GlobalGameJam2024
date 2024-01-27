using Repository;
using UnityEngine.SocialPlatforms.Impl;

namespace Command
{
    public class GameCommand
    {
        private GameRepository _gameRepository;
        private ScoreRepository _scoreRepository;
        private PuzzleRepository _puzzleRepository;

        public GameCommand(
            GameRepository gameRepository,
            ScoreRepository scoreRepository,
            PuzzleRepository puzzleRepository
        )
        {
            _gameRepository = gameRepository;
            _scoreRepository = scoreRepository;
            _puzzleRepository = puzzleRepository;
        }
        
        public void ResetAll()
        {
            _gameRepository.Reset();
            _scoreRepository.Reset();
            _puzzleRepository.Reset();
        }
    }
}