using System.Collections;
using System.Collections.Generic;
using Command;
using Entity;
using NUnit.Framework;
using Repository;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests.Command
{
    public class TestPuzzleCommand
    {
        private PuzzleCommand _puzzleCommand;
        private ScoreRepository _scoreRepository;
        private GameRepository _gameRepository;
        
        [UnitySetUp] public void Setup()
        {
            PuzzleRepository dataset = ScriptableObject.CreateInstance<PuzzleRepository>();
            dataset.Puzzles = new Puzzle[]
            {
               new Puzzle(PuzzleType.BootProgram, new LockType[] { }) 
            };
            
           _scoreRepository = new ScoreRepository();
           _gameRepository = new GameRepository();
           _puzzleCommand = new PuzzleCommand(_gameRepository, _scoreRepository); 
        } 
        
        [UnityTest]
        public IEnumerator Test_StartPuzzle()
        {
            _puzzleCommand.Start(PuzzleType.BootProgram, 1.0);
            Assert.AreEqual(PuzzleType.BootProgram, _gameRepository.CurrentPuzzle.type);
            
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator Test_EndPuzzle()
        {
            _puzzleCommand.Start(PuzzleType.BootProgram, 1.0);
            _puzzleCommand.End(PuzzleType.BootProgram, 2.0);
            Assert.AreEqual(1.0, _scoreRepository.Get(PuzzleType.BootProgram));
            
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator Test_ResetLevel()
        {
            _puzzleCommand.Start(PuzzleType.BootProgram, 1.0);
            _puzzleCommand.End(PuzzleType.BootProgram, 2.0);
            _puzzleCommand.ResetAll();
            Assert.AreEqual(0, _scoreRepository.Get(PuzzleType.BootProgram));
            
            yield return null;
        }
    }
}