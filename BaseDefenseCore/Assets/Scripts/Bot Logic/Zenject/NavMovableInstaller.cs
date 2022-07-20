using BotLogic.Moving;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace BotLogic.Zenject
{
    public class NavMovableInstaller: MonoInstaller
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public override void InstallBindings()
        {
            var mService = new NavMovableService(_navMeshAgent);
            Container.Bind<MovableService>().FromInstance(mService).AsSingle().NonLazy();
        }
    }
}