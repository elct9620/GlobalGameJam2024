﻿using System;
using UnityEngine;

namespace Scenes.DragoObjectSample.Scripts
{
    public class DragoTarget:MonoBehaviour
    {
        public string Name;

        public void Start()
        {
            var boxCollider2D = GetComponent<BoxCollider2D>();

            if (boxCollider2D is null) throw new NullReferenceException("找不到2D碰撞");
        }
    }
}