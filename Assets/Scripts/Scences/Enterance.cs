using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Reflex.Attributes;
using UnityEngine.SceneManagement;

public class Enterance : MonoBehaviour
{
    [Inject] private readonly Command.Level _level;

    public void Start()
    {
        _level.ResetAll();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
