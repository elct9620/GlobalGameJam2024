using System.Collections;
using System.Collections.Generic;
using Command;
using Entity;
using NUnit.Framework;
using Repository;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.Command
{
    public class TestGameCommand
    {
        private GameRepository _gameRepository;
        private ScoreRepository _scoreRepository;
        private PuzzleRepository _puzzleRepository;

        private GameCommand _gameCommand;

        [UnitySetUp]
        public IEnumerator SetUp()
        {
            _gameRepository = new GameRepository();
            _scoreRepository = new ScoreRepository();
            _puzzleRepository = ScriptableObject.CreateInstance<PuzzleRepository>();

            _puzzleRepository.Puzzles = new []
            {
                new Puzzle(PuzzleType.BootProgram,
                    new []
                    {
                        LockType.MusicPlaying
                    })
            };

            _gameCommand = new GameCommand(_gameRepository, _scoreRepository, _puzzleRepository);
            yield return null;
        }

        [UnityTest]
        public IEnumerator GetScores()
        {
            _scoreRepository.Add(PuzzleType.BootProgram, 1.0);
            _scoreRepository.Add(PuzzleType.BootProgram, 2.0);
            _scoreRepository.Add(PuzzleType.LoadingScreen, 3.0);
            
            Dictionary<PuzzleType, double> scores = _gameCommand.GetScores();
            Assert.AreEqual(1.0, scores[PuzzleType.BootProgram]);
            Assert.AreEqual(3.0, scores[PuzzleType.LoadingScreen]);

            yield return null;
        }

        [UnityTest]
        public IEnumerator ResetAll_ClearPuzzle()
        {
            _gameRepository.SetPuzzle(_puzzleRepository.Puzzles[0], 0);
            _gameCommand.ResetAll();

            Assert.AreEqual(null, _gameRepository.CurrentPuzzle);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator ResetAll_ClearScore()
        {
            _scoreRepository.Add(PuzzleType.BootProgram, 1.0);
            _gameCommand.ResetAll();

            Assert.AreEqual(0, _scoreRepository.Get(PuzzleType.BootProgram));
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator ResetAll_ResetPuzzle()
        {
            Puzzle puzzle = _puzzleRepository.Find(PuzzleType.BootProgram);
            puzzle.Unlock(LockType.MusicPlaying);
            
            _gameCommand.ResetAll();

            Assert.AreEqual(false, puzzle.Resolved());
            yield return null;
        }
    }
}