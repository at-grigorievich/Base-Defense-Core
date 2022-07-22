﻿using System;
using LifecycleService;
using UnityEngine;

namespace FightService
{
    public class AttackService
    {
        protected readonly GunData _gunData;

        private float _currentTime;
        public float Distance => _gunData.GunDistance;
        
        public event Action OnAttack;
        public event Action OnEndAttack;

        public AttackService(GunData data)
        {
            _gunData = data;
            _currentTime = _gunData.ReloadingDelay;
        }
        
        public void UpdateReloading() => _currentTime += Time.deltaTime;
        
        public void AddDamage(IDamageable damageable) => 
            damageable.TakeDamage(_gunData.GunDamage);
        
        
        public void TryAttack()
        {
            if (_currentTime >= _gunData.ReloadingDelay)
                StartAttack();
        }
        
        protected virtual void StartAttack()
        {
            _currentTime = 0f;
            OnAttack?.Invoke();
        }

        public virtual void EndAttack()
        {
            OnEndAttack?.Invoke();
        }
    }
}