using System.Collections;
using System.Collections.Generic;
using Entity;
using NUnit.Framework;
using Repository;
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
        
        [SetUp] public void Setup()
        {
           _score = new Score();
           _game = new Game();
           _puzzle = new Puzzle(_game, _score); 
        } 
        
        [Test]
        public void Test_StartPuzzle()
        {
            
            Entity.Puzzle puzzle = new Entity.Puzzle(PuzzleType.BootProgram, 1.0);
            _puzzle.Start(PuzzleType.BootProgram, puzzle.StartAt);
            Assert.AreEqual(puzzle.type, _game.CurrentPuzzle.type);
        }
        
        [Test]
        public void Test_EndPuzzle()
        {
            Entity.Puzzle puzzle = new Entity.Puzzle(PuzzleType.BootProgram, 1.0);
            _puzzle.Start(PuzzleType.BootProgram, puzzle.StartAt);
            _puzzle.End(PuzzleType.BootProgram, 2.0);
            Assert.AreEqual(1.0, _score.Get(PuzzleType.BootProgram));
        }
        
        [Test]
        public void Test_ResetLevel()
        {
            
            Entity.Puzzle puzzle = new Entity.Puzzle(PuzzleType.BootProgram, 1.0);
            _puzzle.Start(PuzzleType.BootProgram, puzzle.StartAt);
            _puzzle.End(PuzzleType.BootProgram, 2.0);
            _puzzle.ResetAll();
            Assert.AreEqual(0, _score.Get(PuzzleType.BootProgram));
        }
    }
}