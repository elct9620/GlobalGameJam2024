using System.Collections;
using System.Collections.Generic;
using Command;
using Reflex.Attributes;
using UnityEngine;

namespace Scenes
{
    public class Level1 : MonoBehaviour
    {
        [Inject] private Level _level;

        void Start()
        {
            _level.Start(Time.time);
        }
    }
}