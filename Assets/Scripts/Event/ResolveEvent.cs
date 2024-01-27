using Entity;
using UnityEngine;

namespace Event
{
    public class ResolveEvent
    {
        public readonly PuzzleType type;

        public ResolveEvent(PuzzleType type)
        {
            this.type = type;
        }
    }
}