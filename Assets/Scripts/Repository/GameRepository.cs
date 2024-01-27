using System;
using Entity;
using UnityEngine;

namespace Repository
{
    public class GameRepository
    {
        public Entity.Puzzle CurrentPuzzle { get; private set; } = null;
        public double CurrentPuzzleStartTime { get; private set;  } = 0;


        public void SetPuzzle(Entity.Puzzle puzzle, double time)
        {
            CurrentPuzzle = puzzle;
            if (CurrentPuzzle == null)
            {
                CurrentPuzzleStartTime = 0;
                return;
            }
            
            CurrentPuzzleStartTime = time;
        } 
        
        public double DeltaTime(double current)
        {
            if (CurrentPuzzle == null)
            {
                return 0;
            } 
            
            return current - CurrentPuzzleStartTime;
        }
        
        public void Reset()
        {
            CurrentPuzzle = null;
            CurrentPuzzleStartTime = 0;
        }
    }
}