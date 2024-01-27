using Entity;
using UnityEngine;

namespace Repository
{
    [CreateAssetMenu(fileName = "PuzzleData", menuName = "ScriptableObjects/PuzzleData", order = 1)]
    public class PuzzleRepository : ScriptableObject
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