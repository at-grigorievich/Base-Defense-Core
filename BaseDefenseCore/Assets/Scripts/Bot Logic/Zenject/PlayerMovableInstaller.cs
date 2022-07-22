using BotLogic.Moving;
using UnityEngine;

namespace BotLogic.Zenject
{
    public class PlayerMovableInstaller: DestinationMovableInstaller
    {
        [SerializeField] private float _autoRotateDetectDistance;
        [SerializeField] private float _autoRotateSpeed;
        [SerializeField] private PlayerBotLogicService _playerBot;
        
        public override void InstallBindings()
        {
            MovableService movableService = new NavMovableService(
                _navMeshAgent, _playerBot, _autoRotateDetectDistance,_autoRotateSpeed);
            Container.BindInstance(movableService).AsSingle().NonLazy();
        }
    }
}