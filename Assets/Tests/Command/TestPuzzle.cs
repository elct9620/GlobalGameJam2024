using System.Collections;
using System.Collections.Generic;
using Dataset;
using Entity;
using NUnit.Framework;
using Repository;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Puzzle = Command.Puzzle;

namespace Tests.Command
{
    public class TestPuzzle
    {
        private Puzzle _puzzle;
        private Score _score;
        private Game _game;
        
        [UnitySetUp] public void Setup()
        {
            PuzzleConstraint dataset = ScriptableObject.CreateInstance<PuzzleConstraint>();
            dataset.Puzzles = new Entity.Puzzle[]
            {
               new Entity.Puzzle(PuzzleType.BootProgram, new LockType[] { }) 
            };
            
           _score = new Score();
           _game = new Game();
           _puzzle = new Puzzle(_game, _score); 
        } 
        
        [UnityTest]
        public IEnumerator Test_StartPuzzle()
        {
            _puzzle.Start(PuzzleType.BootProgram, 1.0);
            Assert.AreEqual(PuzzleType.BootProgram, _game.CurrentPuzzle.type);
            
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator Test_EndPuzzle()
        {
            _puzzle.Start(PuzzleType.BootProgram, 1.0);
            _puzzle.End(PuzzleType.BootProgram, 2.0);
            Assert.AreEqual(1.0, _score.Get(PuzzleType.BootProgram));
            
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator Test_ResetLevel()
        {
            _puzzle.Start(PuzzleType.BootProgram, 1.0);
            _puzzle.End(PuzzleType.BootProgram, 2.0);
            _puzzle.ResetAll();
            Assert.AreEqual(0, _score.Get(PuzzleType.BootProgram));
            
            yield return null;
        }
    }
}