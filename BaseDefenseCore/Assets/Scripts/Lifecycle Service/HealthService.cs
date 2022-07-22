using UnityEngine;

namespace LifecycleService
{
    public class HealthService
    {
        private readonly int _defaultHealth;
        private int _currentHealth;

        public bool IsHealthEnd => _currentHealth <= 0;
        
        public HealthService(HealthData data)
        {
            _defaultHealth = data.DefaultHeath;
        }
        
        public void ResetHealth() => _currentHealth = _defaultHealth;

        public void RemoveHealth(int removedValue)
        {
            _currentHealth -= removedValue;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _defaultHealth);
        }
    }
}