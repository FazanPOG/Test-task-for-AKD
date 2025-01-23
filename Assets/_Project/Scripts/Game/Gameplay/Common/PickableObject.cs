using UnityEngine;

namespace _Project.Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class PickableObject : MonoBehaviour, IPickable
    {
        private Rigidbody _rigidbody;

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        public void PickUp(Transform parent, bool worldPositionStays = false)
        {
            transform.SetParent(parent, worldPositionStays);
            transform.localPosition = Vector3.zero;
            _rigidbody.isKinematic = true;
        }

        public void Drop()
        {
            transform.SetParent(null);
            _rigidbody.isKinematic = false;
        }
    }
}