using Dataset;
using Reflex.Core;
using UnityEngine;
using UnityEngine.Serialization;

public class ProjectInstaller : MonoBehaviour, IInstaller
{
    [FormerlySerializedAs("PuzzleConstraint")] public PuzzleConstraint puzzleConstraint;
    public void InstallBindings(ContainerBuilder builder)
    {
        builder.AddSingleton(puzzleConstraint);
        builder.AddSingleton(typeof(Repository.Score));
        builder.AddSingleton(typeof(Repository.Game));
        builder.AddSingleton(typeof(Command.Puzzle));
    }
}