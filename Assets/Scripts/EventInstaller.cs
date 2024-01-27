    using Entity;
    using Event;
    using Reflex.Core;
    using UnityEngine;

    public class EventInstaller : MonoBehaviour, IInstaller
    {
        public GameEvent<UnlockEvent> unlockEvent;
        public GameEvent<ResolveEvent> resolveEvent;
        
        public void InstallBindings(ContainerBuilder builder)
        {
            builder.AddSingleton(unlockEvent);
            builder.AddSingleton(resolveEvent);
        }
    }