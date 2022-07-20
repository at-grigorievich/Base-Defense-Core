using UnityEngine;
using Zenject;

namespace InputService
{
    public class PlayerInputService: IInputable
    {
        private Joystick _j;

        public Vector2 JoystickValue => new Vector2(_j.Horizontal, _j.Vertical);

        [Inject]
        private void Constructor(Joystick j)
        {
            _j = j;
            SetInputEnable(false);
        }

        public void SetInputEnable(bool enable) => _j.gameObject.SetActive(enable);
    }
}