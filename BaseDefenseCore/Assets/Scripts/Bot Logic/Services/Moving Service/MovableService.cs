using UnityEngine;

namespace BotLogic.Moving
{
    public abstract class MovableService
    {
        public abstract void SetMovableActive(bool enabled);
        
        public abstract void Move(Vector3 direction);
        public abstract void Rotate(Vector3 direction, float smoothTime);
        
        public virtual void SetActiveMove(bool isStop){}
    }
}