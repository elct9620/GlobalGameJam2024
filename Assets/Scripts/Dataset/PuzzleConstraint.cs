using Entity;
using UnityEngine;

namespace Dataset
{
    [CreateAssetMenu(fileName = "PuzzleConstraint", menuName = "ScriptableObjects/PuzzleConstraint", order = 1)]
    public class PuzzleConstraint : ScriptableObject
    {
        public Puzzle[] Puzzles; 
    }
}
