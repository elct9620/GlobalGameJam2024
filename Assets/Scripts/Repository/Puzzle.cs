using Codice.Utils;
using Dataset;
using Entity;

namespace Repository
{
    public class Puzzle
    {
        private readonly PuzzleConstraint _dataset;
        
        public Puzzle(PuzzleConstraint dataset)
        {
           _dataset = dataset; 
        }
        
        public Entity.Puzzle Find(PuzzleType type)
        {
            return _dataset.Find(type);
        }
    }
}