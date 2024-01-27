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
        
        [SetUp] public void Setup()
        {
           _score = new Score();
           _puzzle = new Puzzle(_score); 
        } 
        
        [UnityTest]
        public IEnumerator Test_StartLevel()
        {
            Scene current = new Scene
            {
                name = "Test"
            };
            SceneManager.SetActiveScene(current);
            
            _puzzle.Start( 1.0);
            _puzzle.End(2.0);
            Assert.AreEqual(1.0, _score.Get("Test"));
            
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator Test_ResetLevel()
        {
            Scene current = new Scene
            {
                name = "Test"
            };
            SceneManager.SetActiveScene(current);
            
            _puzzle.Start( 1.0);
            _puzzle.End(2.0);
            _puzzle.ResetAll();
            Assert.AreEqual(0, _score.Get("Test"));
            
            yield return null;
        }
    }
}