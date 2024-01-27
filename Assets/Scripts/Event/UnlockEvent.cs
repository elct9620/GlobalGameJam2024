using Entity;
using UnityEngine;

namespace Event
{
    public class UnlockEvent
    {
        public readonly LockType type;
        
        public UnlockEvent(LockType type)
        {
            this.type = type;
        }
    }
}