using Entity;
using NUnit.Framework;
using Repository;

namespace Tests.Repository
{
    public class TestScore
    {
        private Score _score;
        
        [SetUp]
        public void Setup()
        {
            _score = new Score();
        } 
        
        [Test]
        public void Test_AddScoreByLevel()
        {
            _score.Add(PuzzleType.BootProgram, 1.0);
            Assert.AreEqual(1.0, _score.Get(PuzzleType.BootProgram));
        }
        
        [Test]
        public void Test_GetNonExistingScore()
        {
            Assert.AreEqual(0, _score.Get(PuzzleType.BootProgram));
        }
        
        [Test]
        public void Test_ResetScore()
        {
            _score.Add(PuzzleType.BootProgram, 1.0);
            _score.Reset();
            Assert.AreEqual(0, _score.Get(PuzzleType.BootProgram));
        }
    }
}