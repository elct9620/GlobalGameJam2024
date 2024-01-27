using System.Collections;
using System.Collections.Generic;
using Command;
using NUnit.Framework;
using Repository;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

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
            
            Entity.Puzzle puzzle = new Entity.Puzzle("Test", 1.0);
            _puzzle.Start(puzzle.Name, puzzle.StartAt);
            Assert.AreEqual(puzzle.Name, _game.CurrentPuzzle.Name);
        }
        
        [Test]
        public void Test_EndPuzzle()
        {
            Entity.Puzzle puzzle = new Entity.Puzzle("Test", 1.0);
            _puzzle.Start(puzzle.Name, puzzle.StartAt);
            _puzzle.End(2.0);
            Assert.AreEqual(1.0, _score.Get(puzzle.Name));
        }
        
        [Test]
        public void Test_ResetLevel()
        {
            
            Entity.Puzzle puzzle = new Entity.Puzzle("Test", 1.0);
            _puzzle.Start(puzzle.Name, puzzle.StartAt);
            _puzzle.End(2.0);
            _puzzle.ResetAll();
            Assert.AreEqual(0, _score.Get("Test"));
        }
    }
}