using TMPro;
using UnityEngine;

namespace WinterUniverse
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _interactableText;

        public void UpdateInteractText(string getText)
        {
            _interactableText.text = getText;
        }
    }
}