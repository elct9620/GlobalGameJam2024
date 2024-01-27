using Command;
using NUnit.Framework;
using Repository;

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
        
        [Test]
        public void Test_StartLevel()
        {
            _level.Start("Test", 1.0);
            _level.End(2.0);
            Assert.AreEqual(1.0, _score.Get("Test"));
        }
    }
}