using System;
using UnityEngine;

namespace Scenes
{
    /// <summary>
    ///  https://gamedevbeginner.com/how-to-move-an-object-with-the-mouse-in-unity-in-2d/
    /// </summary>
    public class DragoObject:MonoBehaviour
    {
        public GameObject selectedObject;
        private Vector3 _offset;

        public void Start()
        {
           var boxCollider2D =  selectedObject.GetComponent<BoxCollider2D>();
           if (boxCollider2D is null) throw new NullReferenceException("物件沒有設定(BoxCollider2D)碰撞");
        }

        void Update()
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                var targetObject = Physics2D.OverlapPoint(mousePosition);
                if (targetObject)
                {
                    selectedObject = targetObject.transform.gameObject;
                    _offset = selectedObject.transform.position - mousePosition;
                }
            }
            if (selectedObject)
            {
                selectedObject.transform.position = mousePosition + _offset;
            }
            if (Input.GetMouseButtonUp(0) && selectedObject)
            {
                selectedObject = null;
            }
        }
        
    }
}