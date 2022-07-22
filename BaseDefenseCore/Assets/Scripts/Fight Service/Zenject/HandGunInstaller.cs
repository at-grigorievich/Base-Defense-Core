using UnityEngine;
using Zenject;

namespace FightService.Zenject
{
    public class HandGunInstaller: MonoInstaller
    {
        [SerializeField] protected GunData _gunData;
        [SerializeField] protected Transform _hitPoint;


        public override void InstallBindings()
        {
            AttackService attackService = new AttackService(_gunData);
            Container.BindInstance(attackService).AsSingle().NonLazy();
        }
    }
}