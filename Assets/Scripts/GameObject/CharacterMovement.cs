using System;
using System.Collections;
using System.Collections.Generic;
using Codice.CM.Client.Differences;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 150.0f;
    public Vector3 targetPosition;

    private void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        CaptureMovement();
        Move();
    }

    private void CaptureMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Input.mousePosition;
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );
    }
}