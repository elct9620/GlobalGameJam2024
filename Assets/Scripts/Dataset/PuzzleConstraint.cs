using Entity;
using UnityEngine;

namespace Dataset
{
    [CreateAssetMenu(fileName = "PuzzleConstraint", menuName = "ScriptableObjects/PuzzleConstraint", order = 1)]
    public class PuzzleConstraint : ScriptableObject
    {
        public Puzzle[] Puzzles;

        public Puzzle Find(PuzzleType type)
        {
            foreach (Puzzle puzzle in Puzzles)
            {
                if (puzzle.type == type)
                {
                    return puzzle;
                }
            }

            return null;
        }
    }
}
