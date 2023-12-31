using UnityEngine;

namespace WinterUniverse
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] private Transform _head;
        [SerializeField] private float _distance = 2f;
        [SerializeField] private LayerMask _interactableMask;
        [SerializeField] private PlayerUI _ui;

        private void Update()
        {
            _ui.UpdateInteractText(string.Empty);
            if (Physics.Raycast(_head.position, _head.forward, out RaycastHit hit, _distance))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.TryGetComponent(out IInteractable interactable))
                    {
                        _ui.UpdateInteractText(interactable.GetText());
                    }
                }
            }
        }

        public void TryInteract(bool inputEnabled)
        {
            if (inputEnabled)
            {
                if (Physics.Raycast(_head.position, _head.forward, out RaycastHit hit, _distance))
                {
                    if (hit.collider != null)
                    {
                        if (hit.collider.TryGetComponent(out IInteractable interactable))
                        {
                            interactable.Interact(gameObject);
                        }
                    }
                }
            }
        }
    }
}