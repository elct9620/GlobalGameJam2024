using System;
using Command;
using Reflex.Attributes;
using Repository;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text uiText;
    [Inject] private readonly PuzzleCommand _puzzleCommand;

    // Update is called once per frame
    void Update()
    {
        double delta = _puzzleCommand.DeltaTime(Time.time); 
        if (delta == 0)
        {
            uiText.text = "";
            return;
        }
        
        uiText.text = delta.ToString("F2");
    }
}
