using UnityEngine;

namespace WinterUniverse
{
    public class InteractableActivationButton : MonoBehaviour, IInteractable
    {
        [SerializeField] private Animator _anim;
        [SerializeField] private string _animationName = "Activated";
        [SerializeField] private GameObject _affectedObject;
        [SerializeField] private bool _activated, _singleUse;
        private IInteractable _interactable;
        private bool _used;

        private void Start()
        {
            _interactable = _affectedObject.GetComponent<IInteractable>();
            _anim.SetBool(_animationName, _activated);
        }

        public string GetText()
        {
            if (_activated)
            {
                return "Deactivate";
            }
            else
            {
                return "Activate";
            }
        }

        public void Activate()
        {

        }

        public void Deactivate()
        {

        }

        public void Interact(GameObject who)
        {
            if (_singleUse)
            {
                if (_used)
                {
                    return;
                }
                _used = true;
            }
            _activated = !_activated;
            _anim.SetBool(_animationName, _activated);
            if (_activated)
            {
                _interactable.Activate();
            }
            else
            {
                _interactable.Deactivate();
            }
        }
    }
}