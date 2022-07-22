using System;
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

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.isKinematic = true;
        }
        
        
        public void ShootToTarget(Transform target)
        {
            if(target == null)
                return;
            
            transform.SetParent(null);
            transform.LookAt(target);

            _rb.isKinematic = false;

            Vector3 direction = target.position - transform.position;
            _rb.AddForce(direction*_speed,ForceMode.Impulse);
        }

        
        [ContextMenu("Test Shooting")]
        public void MoveToTarget()
        {
            _rb.isKinematic = false;
            _rb.AddForce(transform.TransformDirection(Vector3.forward)*_speed,ForceMode.Impulse);
        }
    }
}