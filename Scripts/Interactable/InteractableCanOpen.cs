using UnityEngine;

namespace WinterUniverse
{
    public class InteractableCanOpen : MonoBehaviour, IInteractable
    {
        [SerializeField] private Animator _anim;
        [SerializeField] private string _animationName = "Opened";
        [SerializeField] private bool _opened, _unlocked, _canOpenDirectly, _forceOpenWhileUnlock, _forceCloseWhileLock;

        private void Start()
        {
            _anim.SetBool(_animationName, _opened);
        }

        public string GetText()
        {
            if (_opened && _unlocked && _canOpenDirectly)
            {
                return "Close";
            }
            else if (!_opened && _unlocked && _canOpenDirectly)
            {
                return "Open";
            }
            else
            {
                return "Locked";
            }
        }

        public void Activate()
        {
            if (!_unlocked)
            {
                _unlocked = true;
                if (_forceOpenWhileUnlock)
                {
                    _opened = true;
                    _anim.SetBool(_animationName, true);
                }
            }
        }

        public void Deactivate()
        {
            if (_unlocked)
            {
                _unlocked = false;
                if (_forceCloseWhileLock)
                {
                    _opened = false;
                    _anim.SetBool(_animationName, false);
                }
            }
        }

        public void Interact(GameObject who)
        {
            if (_unlocked && _canOpenDirectly)
            {
                _opened = !_opened;
                _anim.SetBool(_animationName, _opened);
            }
        }
    }
}