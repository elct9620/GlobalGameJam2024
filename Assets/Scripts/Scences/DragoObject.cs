using System;
using UnityEngine;

namespace Scenes
{
    /// <summary>
    ///  https://gamedevbeginner.com/how-to-move-an-object-with-the-mouse-in-unity-in-2d/
    /// </summary>
    public class DragoObject:MonoBehaviour
    {
        private GameObject selectedObject;
        private Vector3 _offset;
        

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