using UnityEngine;

namespace _Project.Gameplay
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _carryPoint;
        
        public void Init(IInputHandler inputHandler)
        {
            new PlayerCarryHandler(_camera, inputHandler, _carryPoint);
        }
    }
}