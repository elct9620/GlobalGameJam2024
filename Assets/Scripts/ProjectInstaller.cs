using Reflex.Core;
using UnityEngine;

public class ProjectInstaller : MonoBehaviour, IInstaller
{
    public void InstallBindings(ContainerBuilder builder)
    {
        builder.AddSingleton<Repository.Score>(container => container.Resolve<Repository.Score>());
        builder.AddSingleton<Command.Level>(container => container.Resolve<Command.Level>());
    }
}