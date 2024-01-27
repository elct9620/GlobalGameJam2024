using System.Collections;
using System.Collections.Generic;
using Command;
using Entity;
using Reflex.Attributes;
using UnityEngine;

public class GameWindow : MonoBehaviour
{
    [Inject] private readonly PuzzleCommand _puzzleCommand;
    // Start is called before the first frame update
    void Start()
    {
        _puzzleCommand.Start(PuzzleType.LoadingScreen, Time.time);
    }
}
