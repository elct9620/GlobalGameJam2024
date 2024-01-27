    using Entity;
    using Event;
    using Reflex.Core;
    using UnityEngine;

    public class EventInstaller : MonoBehaviour, IInstaller
    {
        public GameEvent<UnlockEvent> unlockEvent;
        
        public void InstallBindings(ContainerBuilder builder)
        {
            builder.AddSingleton(unlockEvent);
        }
    }