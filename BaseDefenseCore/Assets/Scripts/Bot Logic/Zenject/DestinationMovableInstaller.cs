using BotLogic.Moving;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace BotLogic.Zenject
{
    public class DestinationMovableInstaller: MonoInstaller
    {
        [SerializeField] protected NavMeshAgent _navMeshAgent;

        public override void InstallBindings()
        {
            MovableService mService = new DestinationMovableService(_navMeshAgent);
            Container.Bind<MovableService>().FromInstance(mService).AsSingle().NonLazy();
        }
    }
}