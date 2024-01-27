using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Reflex.Attributes;
using UnityEngine.SceneManagement;

public class Enterance : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
