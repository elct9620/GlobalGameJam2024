using System;
using UnityEngine;

namespace Scenes.DragoObjectSample.Scripts
{
    public class DragoTarget:MonoBehaviour
    {
        public void Start()
        {
            var boxCollider2D = GetComponent<BoxCollider2D>();

            if (boxCollider2D is null) throw new NullReferenceException("找不到2D碰撞");
            
            var component = GetComponent<Rigidbody2D>();

            if (component is null) throw new NullReferenceException("找不到2D剛體");
        }
    }

  
}