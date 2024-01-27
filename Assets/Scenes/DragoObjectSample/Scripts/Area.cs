using System;
using UnityEngine;

namespace Scenes.DragoObjectSample.Scripts
{
    public class Area : MonoBehaviour
    {
        public string KeyObjectName;
        public void Start()
        {
            var boxCollider2D = GetComponent<BoxCollider2D>();

            if (boxCollider2D is null) throw new NullReferenceException("找不到2D碰撞");
            
            boxCollider2D.isTrigger = true;
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == KeyObjectName)
            {
                Debug.Log("做甚麼動作，撞到關鍵物件" + collision.gameObject.name);
            }
            else
            {
                Debug.Log("甚麼都沒做");
            }

            
        }

      
    }
}
