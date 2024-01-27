using System;
using Reflex.Attributes;
using Repository;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text uiText;
    [Inject] private readonly GameRepository _gameRepository;

    // Update is called once per frame
    void Update()
    {
        if (_gameRepository.CurrentPuzzle == null)
        {
            uiText.text = "0.00";
            return;
        }
        
        double delta = Time.time - _gameRepository.CurrentPuzzleStartTime;
        uiText.text = delta.ToString("F2");
    }
}
