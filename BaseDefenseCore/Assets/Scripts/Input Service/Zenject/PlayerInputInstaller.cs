using UnityEngine;
using Zenject;

namespace InputService.Zenject
{
    public class PlayerInputInstaller: MonoInstaller
    {
        [SerializeField] private Joystick _joystick;

        public override void InstallBindings()
        {
            Container.BindInstance(_joystick).AsSingle().NonLazy();
            Container.Bind<PlayerInputService>()
                .To<PlayerInputService>()
                .AsSingle().NonLazy();
        }
    }
}