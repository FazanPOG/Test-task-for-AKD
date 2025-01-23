using System;
using FirstPersonMobileTools;
using UnityEngine;
using Zenject;

namespace _Project.Gameplay
{
    public class DesktopInputHandler : IInputHandler, ITickable
    {
        private Joystick _joystick;
        
        public Vector2 MovementInput { get; private set; }
        
        public event Action<Vector2> OnScreenTouched;

        public void AttachJoystick(Joystick joystick)
        {
            if(_joystick != null)
                throw new Exception();

            _joystick = joystick;
        }
        
        public void Tick()
        {
            if (_joystick != null) 
                MovementInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);

            if (Input.GetMouseButtonDown(0))
                OnScreenTouched?.Invoke(Input.mousePosition);
        }
    }
}