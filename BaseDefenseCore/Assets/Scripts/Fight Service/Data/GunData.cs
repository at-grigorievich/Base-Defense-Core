using UnityEngine;

namespace FightService
{
    [CreateAssetMenu(fileName = "Gun", menuName = "Guns/New Gun Data", order = 0)]
    public class GunData : ScriptableObject
    {
        [field: SerializeField] public float GunDistance { get; private set; }
        [field: SerializeField] public float ReloadingDelay { get; private set; }
        [field:Space(10)]
        [field: SerializeField] public Bullet Ammunition { get; private set; }
    }
}