using System;
using LifecycleService;
using UnityEngine;

namespace FightService
{
    [Serializable]
    public class SetupBulletOptions
    {
        public Transform Parent;
        
        public Vector3 BulletPosition;
        public Vector3 BulletRotation;
        public Vector3 BulletScale = Vector3.one;

        public void SetupBulletInLocalSpace(Bullet bullet)
        {
            bullet.transform.SetParent(Parent);
            
            bullet.transform.localPosition = BulletPosition;
            bullet.transform.localRotation = Quaternion.Euler(BulletRotation);
            bullet.transform.localScale = BulletScale;
        }
    }
    
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Action<Collision> _collisionHit;
        private Action<IDamageable> _onShootCollision;
        
        private Transform _tr;
        private Rigidbody _rb;

        private void Awake()
        {
            _tr = transform;
            _rb = GetComponent<Rigidbody>();
            _rb.isKinematic = true;
        }

        public void Init(Action<IDamageable> callback) => _onShootCollision = callback;
        
        public void ShootToTarget(Transform target)
        {
            if(target == null)
                return;

            _collisionHit = DoDamage;
            
            _tr.SetParent(null);
            _tr.LookAt(target);

            _rb.isKinematic = false;

            Vector3 direction = target.position - _tr.position;
            _rb.AddForce(direction*_speed,ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision collision)
        {
            _collisionHit?.Invoke(collision);
        }



        private void DoDamage(Collision collision)
        {
            _collisionHit = null;
            
            Transform p = collision.transform.parent;

            if(p == null)
                return;

            if (p.TryGetComponent(out IDamageable damageable))
            {
                _onShootCollision?.Invoke(damageable);
            }
        }
    }
}