using UnityEngine;

namespace _Project.Gameplay
{
    public interface IPickable
    {
        void PickUp(Transform parent, bool worldPositionStays = false);
        void Drop();
    }
}