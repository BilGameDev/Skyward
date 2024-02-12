using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    //This binds the dependencies that can be accessed later (Dependecy Injection)
    public override void InstallBindings()
    {
        Container.Bind<BirdMovement>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<TrackMovement>().FromComponentInHierarchy().AsSingle();
    }
}
