using BonusItemService;
using UnityEngine;

namespace BonusSpawnerService
{
    public class BonusSpawnerService: MonoBehaviour
    {
        [SerializeField] private BonusData _bonusData;

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

        private void OnDropBonus()
        {
            Debug.Log("adfafsaasf");
        }
    }
}