using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scenes.DragoObjectSample.Scripts
{
    
    public class DragoTargetUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private GameObject draggingObject;

        public void Start()
        {
            var boxCollider2D = GetComponent<BoxCollider2D>();

            if (boxCollider2D is null) throw new NullReferenceException("找不到2D碰撞");
            
            var rigidbody2D = GetComponent<Rigidbody2D>();

            if (rigidbody2D is null) throw new NullReferenceException("找不到2D剛體");
            
            rigidbody2D.gravityScale = 0;
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            draggingObject = gameObject;
            Debug.Log("Begin Dragging: " + draggingObject.name);
        }

        public void OnDrag(PointerEventData eventData)
        {
            // 可以在這裡更新物件的位置，但這取決於你的需求
            draggingObject.transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("End Dragging: " + draggingObject.name);
            draggingObject = null;
        }
    }


  
}