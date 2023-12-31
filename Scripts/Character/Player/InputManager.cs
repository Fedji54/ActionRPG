using UnityEngine;

namespace WinterUniverse
{
    public class InputManager : MonoBehaviour
    {
        private GameInput _input = null;
        private bool _inputEnabled = true;

        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private PlayerLook _look;
        [SerializeField] private PlayerInteract _interact;

        private void Awake()
        {
            _input = new GameInput();
        }

        private void OnEnable()
        {
            _input.Enable();
            HideCursor();
            _input.Character.Jump.performed += contex => _movement.Jump(_inputEnabled);
            _input.Character.Interact.performed += contex => _interact.TryInteract(_inputEnabled);
        }

        private void OnDisable()
        {
            _input.Character.Jump.performed -= contex => _movement.Jump(_inputEnabled);
            _input.Character.Interact.performed -= contex => _interact.TryInteract(_inputEnabled);
            ShowCursor();
            _input.Disable();
        }

        private void Update()
        {
            if (_inputEnabled)
            {
                _movement.Move(_input.Character.Movement.ReadValue<Vector2>());
            }
            else
            {
                _movement.Move(Vector2.zero);
            }
        }

        private void LateUpdate()
        {
            if (_inputEnabled)
            {
                _look.Look(_input.Character.Look.ReadValue<Vector2>());
            }
        }

        public void ShowCursor()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        public void HideCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}