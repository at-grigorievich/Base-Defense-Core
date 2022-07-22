using System;
using BonusItemService;
using BotLogic;
using UnityEngine;
using Zenject;

namespace Navigation
{
    [RequireComponent(typeof(Collider))]
    public class SafeZoneService : MonoBehaviour
    {
        private ITargetable _targetableCache;

        [Inject] private BonusContainerPresenter _bonusPresenter;
        
        private void OnTriggerEnter(Collider other)
        {
            _bonusPresenter.UpdateTotalCount();
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