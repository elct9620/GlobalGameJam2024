using Command;
using NUnit.Framework;

namespace Tests.Command
{
    public class TestLevel
    {
        private Level _level;
        
        [SetUp] public void Setup()
        {
           _level = new Level(); 
        } 
        
        [Test]
        public void Test_StartLevel()
        {
            _level.Start(1.0);
            Assert.AreEqual(1.0, _level.End(2.0));
        }
    }
}