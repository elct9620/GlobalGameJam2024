using System;
using System.Collections;
using System.Collections.Generic;
using Command;
using Entity;
using Event;
using Reflex.Attributes;
using UnityEngine;

public class GameWindow : MonoBehaviour, IGameEventHandler<ResolveEvent>
{
    public GameObject loadingScreen;
    public GameObject resultScreen;
    
    [Inject] private readonly GameEvent<ResolveEvent> _resolveEvent;
    [Inject] private readonly PuzzleCommand _puzzleCommand;

    void Start()
    {
        _resolveEvent.AddListener(this);
        _puzzleCommand.Start(PuzzleType.LoadingScreen, Time.time);
    }
    
    void OnDestroy()
    {
        _resolveEvent.RemoveListener(this);
    }


    public void OnGameEvent(ResolveEvent payload)
    {
        if (payload.type == PuzzleType.LoadingScreen)
        {
            loadingScreen.SetActive(false);
            resultScreen.SetActive(true);
        }
    }
}
