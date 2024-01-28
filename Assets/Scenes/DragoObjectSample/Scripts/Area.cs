using System;
using Command;
using Entity;
using Reflex.Attributes;
using UnityEngine;

namespace Scenes.DragoObjectSample.Scripts
{
    public class Area : MonoBehaviour
    {
        [Inject] private readonly UnlockCommand _unlockCommand;
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
                _unlockCommand.Unlock(LockType.BossToTrash, Time.time);
                Debug.Log("撞到關鍵物品");
            }
            else
            {
                Debug.Log("甚麼都沒做");
            }

            
        }

      
    }
}
