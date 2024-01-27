using System;
using Entity;

namespace Repository
{
    public class Game
    {
        public Puzzle CurrentPuzzle { get; private set; } = null;


        public void SetPuzzle(Puzzle puzzle)
        {
            CurrentPuzzle = puzzle;
        } 
    }
}