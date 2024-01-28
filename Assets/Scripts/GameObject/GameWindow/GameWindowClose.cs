using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWindowClose : MonoBehaviour
{
    public GameObject targetApplication;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           targetApplication.SetActive(false); 
        }        
    }
}
