using System;
using UnityEngine;

namespace _Project.Gameplay
{
    public class PlayerCarryHandler
    {
        private const float PICK_UP_DISTANCE = 5f;
        
        private readonly Camera _playerCamera;
        private readonly Transform _carryPoint;

        private IPickable _currentCarryObject;
        
        public PlayerCarryHandler(Camera playerCamera, IInputHandler inputHandler, Transform carryPoint)
        {
            _playerCamera = playerCamera;
            _carryPoint = carryPoint;
            
            inputHandler.OnScreenTouched += ScreenTouched;
        }

        private void ScreenTouched(Vector2 touchPosition)
        {
            if (_currentCarryObject != null)
            {
                Drop();
                return;
            }
            
            Ray ray = _playerCamera.ScreenPointToRay(touchPosition);
            
            if(Physics.Raycast(ray.origin, ray.direction, out RaycastHit raycastHit, PICK_UP_DISTANCE));
            {
                if(raycastHit.collider.TryGetComponent(out IPickable pickableObject))
                    PickUp(pickableObject);
            }
        }

        private void PickUp(IPickable pickable)
        {
            _currentCarryObject = pickable;
            _currentCarryObject.PickUp(_carryPoint);
        }

        private void Drop()
        {
            if(_currentCarryObject == null)
                throw new Exception();
            
            _currentCarryObject.Drop();
            _currentCarryObject = null;
        }
    }
}