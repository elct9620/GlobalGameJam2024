using System;
using UnityEngine.Serialization;

namespace Entity
{
    [Serializable]
    public class Puzzle
    {
        [FormerlySerializedAs("Type")] public PuzzleType type;
        [FormerlySerializedAs("Locks")] public LockType[] locks;
        
        public Puzzle(PuzzleType type, LockType[] locks)
        {
            this.type = type;
            this.locks = locks;
        }
    }
}