using System;
using BotLogic;
using UnityEngine;

namespace Navigation
{
    [RequireComponent(typeof(Collider))]
    public class SafeZoneService : MonoBehaviour
    {
        private ITargetable _targetableCache;
        
        private void OnTriggerEnter(Collider other)
        {
            CheckToTarget(other,targetable => targetable.SetTargetAvailable(false));
        }

        private void OnTriggerExit(Collider other)
        {
            CheckToTarget(other,targetable => targetable.SetTargetAvailable(true));
        }

        private void CheckToTarget(Collider collider,Action<ITargetable> callback)
        {
            if (collider.TryGetComponent(out ITargetable targetable))
            {
                callback?.Invoke(targetable);
            }
        }
    }
}