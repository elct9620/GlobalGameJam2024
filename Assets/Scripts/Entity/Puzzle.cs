using System;
using UnityEngine.Serialization;

namespace Entity
{
    [Serializable]
    public class Puzzle
    {
        [FormerlySerializedAs("Type")] public PuzzleType type;
        [FormerlySerializedAs("Locks")] public LockType[] locks;
        public double StartAt { get; private set; }
        public double EndAt { get; private set; }
        
        public Puzzle(PuzzleType type, double time)
        {
            this.type = type;
            StartAt = time;
        }
        
        public void End(double time)
        {
            EndAt = time;
        }
        
        public double Delta()
        {
            return EndAt - StartAt;
        }
        
        public double Delta(double time)
        {
            return time - StartAt;
        }
    }
}