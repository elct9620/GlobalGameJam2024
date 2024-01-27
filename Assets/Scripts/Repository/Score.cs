using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Repository
{
    public class Score
    {
        private Dictionary<string, double> scores = new();
        
        public double Get(string name)
        {
            return scores[name];
        }

        public void Add(string name, double score)
        {
            scores.Add(name, score);
        }
    }
}