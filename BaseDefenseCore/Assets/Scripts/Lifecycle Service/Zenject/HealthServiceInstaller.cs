using UnityEngine;
using Zenject;

namespace LifecycleService.Zenject
{
    public class HealthServiceInstaller: MonoInstaller
    {
        [SerializeField] private HealthData _healthData;

        public override void InstallBindings()
        {
            HealthService hs = new HealthService(_healthData);
            Container.BindInstance(hs).AsSingle().NonLazy();
        }
    }
}