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
    
    [RequireComponent(typeof())]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private Transform _target;

        private Action _moveToTarget;
        
        private void Update()
        {
            _moveToTarget?.Invoke();
        }

        public void InitTarget(Transform target) => _target = target;

        public void Shoot()
        {
            if(_target == null)
                return;
            
            transform.SetParent(null);
            transform.LookAt(_target);
            
            _moveToTarget = MoveToTarget;
        }

        private void MoveToTarget()
        {
            transform.Translate(Vector3.forward*_speed*Time.deltaTime);
            //transform.position = Vector3.MoveTowards(transform.position,
                //_target.position,
                //_speed * Time.deltaTime);
        }
    }
}