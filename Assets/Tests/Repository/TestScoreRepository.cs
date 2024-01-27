using Entity;
using NUnit.Framework;
using Repository;

namespace Tests.Repository
{
    public class TestScoreRepository
    {
        private ScoreRepository _scoreRepository;
        
        [SetUp]
        public void Setup()
        {
            _scoreRepository = new ScoreRepository();
        } 
        
        [Test]
        public void Test_AddScoreByLevel()
        {
            _scoreRepository.Add(PuzzleType.BootProgram, 1.0);
            Assert.AreEqual(1.0, _scoreRepository.Get(PuzzleType.BootProgram));
        }
        
        [Test]
        public void Test_GetNonExistingScore()
        {
            Assert.AreEqual(0, _scoreRepository.Get(PuzzleType.BootProgram));
        }
        
        [Test]
        public void Test_ResetScore()
        {
            _scoreRepository.Add(PuzzleType.BootProgram, 1.0);
            _scoreRepository.Reset();
            Assert.AreEqual(0, _scoreRepository.Get(PuzzleType.BootProgram));
        }
    }
}