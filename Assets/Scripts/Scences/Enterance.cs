using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;
using Reflex.Attributes;
using UnityEngine.SceneManagement;

public class Enterance : MonoBehaviour
{
    [Inject] private readonly Command.PuzzleCommand _puzzleCommand;

    public void StartGame()
    {
        _puzzleCommand.Start(PuzzleType.BootProgram, Time.time);
    }
}
