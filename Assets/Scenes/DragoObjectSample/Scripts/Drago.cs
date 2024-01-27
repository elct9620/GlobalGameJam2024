using UnityEngine;

namespace Scenes.DragoObjectSample.Scripts
{
    /// <summary>
    ///  https://gamedevbeginner.com/how-to-move-an-object-with-the-mouse-in-unity-in-2d/
    /// </summary>
    public class Drago:MonoBehaviour
    {
        private GameObject _selectedObject;
        private Vector3 _offset;
        

        void Update()
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                var targetObject = Physics2D.OverlapPoint(mousePosition);
                
                if (targetObject)
                {
                    if (targetObject.GetComponent<DragoTarget>())
                    {
                        _selectedObject = targetObject.transform.gameObject;
                        _offset = _selectedObject.transform.position - mousePosition;
                    }
                }
            }
            if (_selectedObject)
            {
                _selectedObject.transform.position = mousePosition + _offset;
            }
            if (Input.GetMouseButtonUp(0) && _selectedObject)
            {
                _selectedObject = null;
            }
        }
        
    }
}