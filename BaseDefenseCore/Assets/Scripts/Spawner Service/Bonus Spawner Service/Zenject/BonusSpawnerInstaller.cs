using UnityEngine;
using Zenject;

namespace BonusSpawnerService.Zenject
{
    public class BonusSpawnerInstaller: MonoInstaller
    {
        [SerializeField] private BonusSpawnerService _spawner;

        public override void InstallBindings()
        {
            Container.BindInstance(_spawner).AsSingle().NonLazy();
        }
    }
}