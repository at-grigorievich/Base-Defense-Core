using BotLogic.Moving;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace BotLogic.Zenject
{
    public class NavMovableInstaller: MonoInstaller
    {
        [SerializeField] private bool IsDestinationMovable;
        
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public override void InstallBindings()
        {
            MovableService mService = !IsDestinationMovable
                ? new NavMovableService(_navMeshAgent)
                : new DestinationMovableService(_navMeshAgent);

            Container.Bind<MovableService>().FromInstance(mService).AsSingle().NonLazy();
        }
    }
}