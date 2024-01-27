using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leave : MonoBehaviour
{
 
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }   
    }
    public void QuitGame()
    {
        Debug.Log("Â÷¶}¹CÀ¸");
        Application.Quit();
    }
}
