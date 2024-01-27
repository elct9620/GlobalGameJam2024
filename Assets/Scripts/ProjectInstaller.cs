using Command;
using Reflex.Core;
using Repository;
using UnityEngine;

public class ProjectInstaller : MonoBehaviour, IInstaller
{
    public PuzzleRepository puzzleRepository;
    public void InstallBindings(ContainerBuilder builder)
    {
        builder.AddSingleton(puzzleRepository);
        builder.AddSingleton(typeof(ScoreRepository));
        builder.AddSingleton(typeof(GameRepository));
        builder.AddSingleton(typeof(PuzzleCommand));
    }
}