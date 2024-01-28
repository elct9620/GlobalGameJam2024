using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWindowClose : MonoBehaviour
{
    public GameObject targetApplication;

    // Update is called once per frame
    public void Close()
    {
        targetApplication.SetActive(false); 
    }
}
