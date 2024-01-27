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
        
        [CreateAssetMenu(fileName = "UnlockEvent", menuName = "Events/UnlockEvent", order = 1)]
        public class UnlockEventAsset : GameEvent<UnlockEvent> {}
    }
}