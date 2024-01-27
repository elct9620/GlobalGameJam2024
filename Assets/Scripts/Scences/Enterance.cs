using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Reflex.Attributes;
using UnityEngine.SceneManagement;

public class Enterance : MonoBehaviour
{
    [Inject] private readonly Command.Puzzle _puzzle;

    public void StartGame()
    {
        _puzzle.ResetAll();
        _puzzle.Start("Game", Time.time);
    }
}
