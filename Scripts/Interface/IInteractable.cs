using UnityEngine;

namespace WinterUniverse
{
    public interface IInteractable
    {
        public string GetText();
        public void Activate();
        public void Deactivate();
        public void Interact(GameObject who);
    }
}