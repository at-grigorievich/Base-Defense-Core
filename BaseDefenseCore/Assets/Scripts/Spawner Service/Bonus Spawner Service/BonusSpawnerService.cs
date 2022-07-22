using BonusItemService;
using UnityEngine;
using Zenject;

namespace BonusSpawnerService
{
    public class BonusSpawnerService: MonoBehaviour
    {
        [SerializeField] private BonusData _bonusData;

        [Inject] private BonusContainerPresenter _bonusPresenter;
        
        public void TrySpawnBonus(object sender, Vector3 targetPos)
        {
            float rnd = Random.value;

            if (rnd.CompareTo(_bonusData.DropChance) <= 0)
            {
                //TODO: Remake to Object Pool
                IBonusDroper droper = 
                    Instantiate(_bonusData.BonusPrefab, targetPos, Quaternion.identity);
                droper.OnDropBonus += OnDropBonus;
            }
        }

        private void OnDropBonus() => _bonusPresenter.AddCurrentCount();
    }
}