using System.Collections;
using System.Collections.Generic;
using Entity;
using Event;
using Reflex.Attributes;
using UnityEngine;

public class OpenGame : MonoBehaviour, IGameEventHandler<ResolveEvent>
{
    [Inject] private readonly GameEvent<ResolveEvent> _resolveEvent;
    
    public bool allowOpen = false;
    public GameObject targetApplication;
    void Start()
    {
        _resolveEvent.AddListener(this);    
    }

    public void OnDestroy()
    {
        _resolveEvent.RemoveListener(this);
    }
    
    void Update()
    {
        if (allowOpen && Input.GetMouseButtonDown(0))
        {
            targetApplication.SetActive(true);
        }
    }

    public void OnGameEvent(ResolveEvent payload)
    {
        if (payload.type == PuzzleType.BootProgram)
        {
            allowOpen = true;
        }
    }
}
