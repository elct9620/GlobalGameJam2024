using System;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text uiText;
    [Inject] private readonly Command.Puzzle _puzzle;

    public void Start()
    {
        Debug.Log(_puzzle);
    }

    // Update is called once per frame
    void Update()
    {
        if (_puzzle.Current() == null)
        {
            uiText.text = "";
            return;
        }
        
        double delta = _puzzle.Current().Delta(Time.time);
        uiText.text = delta.ToString("F2");
    }
}
