using System;
using UnityEngine;

namespace LifecycleService
{
    public interface IDamageable
    {
        event EventHandler<Vector3> OnDieInPlace;

        void ResetHealth();
        void TakeDamage(int damageCount);
    }
}