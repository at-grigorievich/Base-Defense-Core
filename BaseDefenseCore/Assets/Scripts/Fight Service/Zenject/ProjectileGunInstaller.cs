using UnityEngine;

namespace FightService.Zenject
{
    public class ProjectileGunInstaller: HandGunInstaller
    {
        [SerializeField] private SetupBulletOptions _bulletOptions;
        [SerializeField] private string _enemyMask;

        public override void InstallBindings()
        {
            AttackService attackService = 
                new ProjectileAttackService(_bulletOptions, _hitPoint, _enemyMask, _gunData);

            Container.BindInstance(attackService).AsSingle().NonLazy();
        }
    }
}