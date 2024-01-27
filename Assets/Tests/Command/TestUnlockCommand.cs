using System.Collections;
using Command;
using Entity;
using NUnit.Framework;
using Repository;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.Command
{
    public class TestUnlockCommand
    {
        private UnlockCommand _unlockCommand;
        [UnitySetUp] public IEnumerator SetUp()
        {
            Puzzle puzzle = new Puzzle(PuzzleType.BootProgram, new LockType[]
            {
                LockType.MusicPlaying
            });
            
            GameRepository gameRepository = new GameRepository();
            ScoreRepository scoreRepository = new ScoreRepository();
            
            gameRepository.SetPuzzle(puzzle, 0.0);
            _unlockCommand = new UnlockCommand(gameRepository, scoreRepository);
            
            yield return null;
        }
        
        [UnityTest] public IEnumerator Test_Unlock()
        {
            bool res = _unlockCommand.Unlock(LockType.MusicPlaying, 1); 
            Assert.AreEqual(true, res);
            
            yield return null;
        }
    }
}