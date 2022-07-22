using UnityEngine;

namespace BonusItemService
{
    public class RotateAnimation: IAnimated
    {
        private readonly Transform _transform;
        
        private readonly Vector3 _rotateDirection;

        public RotateAnimation(Transform transform, Vector3 direction, float speed)
        {
            _transform = transform;
            _rotateDirection = direction.normalized * speed;
        }

        public void Animate()
        {
            _transform.Rotate(_rotateDirection*Time.deltaTime);
        }
    }
}