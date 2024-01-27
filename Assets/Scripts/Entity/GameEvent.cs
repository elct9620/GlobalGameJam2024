using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Entity
{
    public class GameEvent<T>
    {
        private List<IGameEventHandler<T>> listeners = new List<IGameEventHandler<T>>();
        
        public void Emit(T payload)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnGameEvent(payload);
            }
        }
        
        public void AddListener(IGameEventHandler<T> listener)
        {
            listeners.Add(listener);
        }
        
        public void RemoveListener(IGameEventHandler<T> listener)
        {
            listeners.Remove(listener);
        }
    }
}