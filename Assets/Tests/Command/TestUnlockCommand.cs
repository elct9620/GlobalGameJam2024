using System.Collections;
using Command;
using Entity;
using Event;
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
            GameEvent<UnlockEvent> unlockEvent = ScriptableObject.CreateInstance<GameEvent<UnlockEvent>>();
            GameEvent<ResolveEvent> resolveEvent = ScriptableObject.CreateInstance<GameEvent<ResolveEvent>>();
            
            gameRepository.SetPuzzle(puzzle, 0.0);
            _unlockCommand = new UnlockCommand(gameRepository, scoreRepository, unlockEvent, resolveEvent);
            
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