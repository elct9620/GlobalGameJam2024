using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAwayButton : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0f));

        Vector2 moveDirection = (Vector2)transform.position - (Vector2)mouseWorldPosition;
        moveDirection.Normalize();


        Vector2 newPosition = (Vector2)transform.position + moveDirection * speed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, Camera.main.ViewportToWorldPoint(Vector3.zero).x, Camera.main.ViewportToWorldPoint(Vector3.one).x);
        newPosition.y = Mathf.Clamp(newPosition.y, Camera.main.ViewportToWorldPoint(Vector3.zero).y, Camera.main.ViewportToWorldPoint(Vector3.one).y);

        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }
}



