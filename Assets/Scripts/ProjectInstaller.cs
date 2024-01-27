using Command;
using Entity;
using Event;
using Reflex.Core;
using Repository;
using UnityEngine;

public class ProjectInstaller : MonoBehaviour, IInstaller
{
    public PuzzleRepository puzzleRepository;
    public void InstallBindings(ContainerBuilder builder)
    {
        builder.AddSingleton(puzzleRepository);
        builder.AddSingleton(typeof(GameEvent<UnlockEvent>));
        builder.AddSingleton(typeof(GameEvent<ResolveEvent>));
        builder.AddSingleton(typeof(ScoreRepository));
        builder.AddSingleton(typeof(GameRepository));
        builder.AddSingleton(typeof(PuzzleCommand));
        builder.AddSingleton(typeof(UnlockCommand));
    }
}