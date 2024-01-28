using System;
using UnityEngine;

public class AppearWithCharacter : MonoBehaviour
{

    public GameObject target;
    private void Start()
    {
        
    }

    public  Transform secondObject;
    private float     specifiedDistance = 200f;
    private bool      hasTriggered      = false;
    private float     lastTriggerTime   = 0f;
    private bool      isObjectActive    = false; // 追蹤物件狀態

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, secondObject.position);

        if (distance < specifiedDistance)
        {
            if (!isObjectActive)
            {
                TriggerEvent(true); // 打開物件
                isObjectActive = true;
            }
        }
        else
        {
            if (isObjectActive)
            {
                TriggerEvent(false); // 關閉物件
                isObjectActive = false;
            }
        }
    }

    private void TriggerEvent(bool isActive)
    {
        // 修改物件的啟用狀態
        // 這裡假設你的 UI 物件是個 GameObject，可以啟用/禁用
        target.SetActive(isActive);

        // 你也可以在這裡執行其他事件，根據 isActive 的值
        if (isActive)
        {
            Debug.Log("物件已打開");
        }
        else
        {
            Debug.Log("物件已關閉");
        }
    }
    
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, secondObject.position);
        Gizmos.DrawWireSphere(transform.position, specifiedDistance);
    }
    
}