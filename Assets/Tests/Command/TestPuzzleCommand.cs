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
    public class TestPuzzleCommand
    {
        private PuzzleCommand _puzzleCommand;
        [UnitySetUp] public IEnumerator SetUp()
        {
            PuzzleRepository puzzleRepository = ScriptableObject.CreateInstance<PuzzleRepository>();
            puzzleRepository.Puzzles = new[]
            {
                new Puzzle(PuzzleType.BootProgram, new LockType[] { })
            };
            
            GameRepository gameRepository = new GameRepository();
            
            _puzzleCommand = new PuzzleCommand(puzzleRepository, gameRepository);
            
            yield return null;
        }
        
        [UnityTest] public IEnumerator Test_Start()
        {
            _puzzleCommand.Start(PuzzleType.BootProgram, 0);
            double deltaTime = _puzzleCommand.DeltaTime(1);
            Assert.AreEqual(1, deltaTime);
            
            yield return null;
        }
        
        [UnityTest] public IEnumerator Test_StartTwice()
        {
            _puzzleCommand.Start(PuzzleType.BootProgram, 0);
            _puzzleCommand.Start(PuzzleType.BootProgram, 1);
            double deltaTime = _puzzleCommand.DeltaTime(1);
            Assert.AreEqual(1, deltaTime);
            
            yield return null;
        }
        
        [UnityTest] public IEnumerator Test_CurrentPuzzle()
        {
            _puzzleCommand.Start(PuzzleType.BootProgram, 0);
            PuzzleType type = _puzzleCommand.CurrentPuzzle();
            Assert.AreEqual(PuzzleType.BootProgram, type);
            
            yield return null;
        }
        
        [UnityTest] public IEnumerator Test_CurrentPuzzleWhenNone()
        {
            PuzzleType type = _puzzleCommand.CurrentPuzzle();
            Assert.AreEqual(PuzzleType.None, type);
            
            yield return null;
        }
        
        [UnityTest] public IEnumerator Test_DeltaTimeWhenNone()
        {
            double deltaTime = _puzzleCommand.DeltaTime(1);
            Assert.AreEqual(0, deltaTime);
            
            yield return null;
        }
        
        [UnityTest] public IEnumerator Test_DeltaTimeWhenStarted()
        {
            _puzzleCommand.Start(PuzzleType.BootProgram, 0);
            double deltaTime = _puzzleCommand.DeltaTime(1);
            Assert.AreEqual(1, deltaTime);
            
            yield return null;
        }
    }
}