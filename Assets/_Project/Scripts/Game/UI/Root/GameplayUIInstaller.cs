using _Project.Gameplay;
using FirstPersonMobileTools;
using UnityEngine;
using Zenject;

namespace _Project.UI.Root
{
    public class GameplayUIInstaller : MonoInstaller
    {
        [SerializeField] private Canvas _rootCanvas;
        [SerializeField] private Joystick _joystickPrefab;
        
        public override void InstallBindings()
        {
            BindJoystick();
        }

        private void BindJoystick()
        {
            var inputHandler = Container.Resolve<IInputHandler>();
            
            var joystick = Container.InstantiatePrefabForComponent<Joystick>(_joystickPrefab, _rootCanvas.transform);
            
            if(inputHandler is MobileInputHandler mobileInputHandler)
                mobileInputHandler.AttachJoystick(joystick);
            
            if(inputHandler is DesktopInputHandler desktopInputHandler)
                desktopInputHandler.AttachJoystick(joystick);
        }
    }
}