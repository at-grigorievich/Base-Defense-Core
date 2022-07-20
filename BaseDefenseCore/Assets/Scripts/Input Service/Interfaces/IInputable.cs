using UnityEngine;

namespace InputService
{
    public interface IInputable
    {
        public Vector2 JoystickValue { get; }
    }
}