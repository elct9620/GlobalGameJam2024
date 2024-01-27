using System;
using System.Collections;
using System.Collections.Generic;
using Command;
using Entity;
using Event;
using Reflex.Attributes;
using UnityEngine;

public class GameWindow : MonoBehaviour, IGameEventHandler<UnlockEvent>
{
    public GameObject loadingScreen;
    public GameObject resultScreen;
    
    [Inject] private readonly GameEvent<UnlockEvent> _unlockEvent; 
    [Inject] private readonly PuzzleCommand _puzzleCommand;

    void Start()
    {
        _unlockEvent.AddListener(this);
        _puzzleCommand.Start(PuzzleType.LoadingScreen, Time.time);
    }
    
    void OnDestroy()
    {
        _unlockEvent.RemoveListener(this);
    }

    public void OnGameEvent(UnlockEvent payload)
    {
        if(payload.type == LockType.LoadingProgress)
        {
            loadingScreen.SetActive(false);
            resultScreen.SetActive(true);
        }
    }
}
