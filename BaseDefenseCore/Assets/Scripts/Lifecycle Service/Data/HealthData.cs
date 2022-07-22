using UnityEngine;

namespace LifecycleService
{
    [CreateAssetMenu(fileName = "Health", menuName = "Health/New Health Data", order = 0)]
    public class HealthData : ScriptableObject
    {
        [field: SerializeField]
        public int DefaultHeath { get; private set; }
    }
}