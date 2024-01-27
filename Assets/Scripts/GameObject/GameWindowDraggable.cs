using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class GameWindowDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public RectTransform target;
    
    private Vector3 initPosition;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(transform as RectTransform, eventData.position, eventData.enterEventCamera, out initPosition);
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(transform as RectTransform, eventData.position, eventData.enterEventCamera, out var position);
        Vector3 offset = initPosition - position;
        
        target.position -= offset;
        initPosition = position;
    }
}
