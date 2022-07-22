using UnityEngine;

namespace FightService
{
    public class ProjectileAttackService: AttackService
    {
        private readonly SetupBulletOptions _bulletOptions;
       
        private readonly Transform _raycastTarget;
        
        private readonly LayerMask _enemyMask;
        
        
        private Bullet _bulletInstance;
        private Transform _hitTarget;
        
        
        public ProjectileAttackService(SetupBulletOptions bulletOptions,
            Transform raycastTarget,string enemyMask,GunData data) : base(data)
        {
            _bulletOptions = bulletOptions;
            _raycastTarget = raycastTarget;
            _enemyMask = LayerMask.GetMask(enemyMask);
            
            CreateProjectile();
        }

        protected override void StartAttack()
        {
            _hitTarget = TryRaycast();
            if (_hitTarget != null)
            {
                if (_bulletInstance == null) return;
                base.StartAttack();
            }
        }

        public override void EndAttack()
        {
            if (_bulletInstance != null)
            {
                _bulletInstance.ShootToTarget(TryRaycast() ?? _hitTarget);
                CreateProjectile();
            }
            base.EndAttack();
        }

        private Transform TryRaycast()
        {
            RaycastHit hit;
            
            Vector3 start = _raycastTarget.position;
            Vector3 dir = _raycastTarget.TransformDirection(Vector3.forward);

            if (Physics.Raycast(start, dir,out hit, _gunData.GunDistance, _enemyMask))
            {
                return hit.transform;
            }

            return null;
        }
        
        //TODO: Сhange to pool
        private void CreateProjectile()
        {
            _bulletInstance = GameObject.Instantiate(_gunData.Ammunition);
            _bulletOptions.SetupBulletInLocalSpace(_bulletInstance);
        }
    }
}