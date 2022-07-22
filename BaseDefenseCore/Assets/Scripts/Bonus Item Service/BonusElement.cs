using System;
using UnityEngine;

namespace BonusItemService
{
    [RequireComponent(typeof(Collider))]
    public class BonusElement : MonoBehaviour, IBonusDroper
    {
        [SerializeField] private Vector3 _animateDirection;
        [SerializeField] private float _animateSpeed;
        [SerializeField] private Transform _animateObject;
        
        public event Action OnDropBonus;
        
        private IAnimated _rotateAnimation;

        private void Awake()
        {
            _rotateAnimation = 
                new RotateAnimation(_animateObject, _animateDirection, _animateSpeed);

            OnDropBonus += () => Destroy(gameObject);
        }

        private void Update() => _rotateAnimation?.Animate();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IBonusDetector detector))
            {
                OnDropBonus?.Invoke();
            }
        }
        
    }
}