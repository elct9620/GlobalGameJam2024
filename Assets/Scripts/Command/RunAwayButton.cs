using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class RunAwayButton : MonoBehaviour
{
    [SerializeField] private float speed = 40f;
    float cameraMinX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
    float cameraMaxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    float cameraMinY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
    float cameraMaxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;


    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 moveDirection = mousePosition - transform.position;


        moveDirection.z = 0;

        moveDirection.Normalize();

       

        Vector2 newPosition = transform.position + (moveDirection * speed * Time.deltaTime);
        if (newPosition.x >= 639.8)
        {
            moveDirection = moveDirection * Vector2.left *speed*2;
        }
        else if(newPosition.x<=0)
        {
            moveDirection = moveDirection * Vector2.right;
        }
        else if(newPosition.y >= 416.8)
        {
            moveDirection = moveDirection * Vector2.down;
        }
        else if (newPosition.y <= 0)
        {
            moveDirection = moveDirection * Vector2.up;
        }

        transform.Translate(-moveDirection * speed * Time.deltaTime);
    }
}






