using System.Collections;
using System.Collections.Generic;
using Command;
using NUnit.Framework;
using Repository;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests.Command
{
    public class TestLevel
    {
        private Level _level;
        private Score _score;
        
        [SetUp] public void Setup()
        {
           _score = new Score();
           _level = new Level(_score); 
        } 
        
        [UnityTest]
        public IEnumerator Test_StartLevel()
        {
            Scene current = new Scene
            {
                name = "Test"
            };
            SceneManager.SetActiveScene(current);
            
            _level.Start( 1.0);
            _level.End(2.0);
            Assert.AreEqual(1.0, _score.Get("Test"));
            
            yield return null;
        }
    }
}