using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace Entity
{
    [Serializable]
    public class Puzzle
    {
        [FormerlySerializedAs("Type")] public PuzzleType type;
        [FormerlySerializedAs("Locks")] public LockType[] locks;
        
        private Dictionary<LockType, bool> _unlocked = new Dictionary<LockType, bool>();
        
        public Puzzle(PuzzleType type, LockType[] locks)
        {
            this.type = type;
            this.locks = locks;
        }
        
       public void Unlock(LockType type)
       {
           _unlocked[type] = true;
       } 
       
       public bool Resolved() 
       {
           foreach (LockType lockType in locks)
           {
               if (!_unlocked.ContainsKey(lockType))
               {
                   return false;
               }
               
                if (!_unlocked[lockType])
                {
                     return false;
                }
           }

           return true;
       }
    }
}