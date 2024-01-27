using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAwayButton : MonoBehaviour
{
    [SerializeField] private float speed = 40f;

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 moveDirection = mousePosition - transform.position;


        moveDirection.z = 0;

        moveDirection.Normalize();

        transform.Translate(-moveDirection * speed * Time.deltaTime);
    }
}


