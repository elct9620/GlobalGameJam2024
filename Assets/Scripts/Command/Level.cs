using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Command
{
    public class Level {
        private double _startAt;

        public void Start(double time)
        {
            _startAt = time;
        }

        public double End(double time)
        {
           return time - _startAt; 
        }
    }   
}