using BonusItemService;
using UnityEngine;

namespace BonusSpawnerService
{
    [CreateAssetMenu(fileName = "Bonus", menuName = "Bonus/New Bonus", order = 0)]
    public class BonusData : ScriptableObject
    {
        [field: SerializeField] public BonusElement BonusPrefab { get; private set; }
        [field: Space(10)]
        [field: Range(0f,1f)]
        [field: SerializeField] public float DropChance { get; private set; }
    }
}