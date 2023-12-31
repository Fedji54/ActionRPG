using UnityEngine;

namespace WinterUniverse
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _cc;
        [SerializeField] private Animator _anim;
        private Vector3 _moveVector, _velocity;
        private float _hor, _ver;
        private readonly float _gravity = -20f;
        private bool _isGrounded;

        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _moveSpeed = 4f;
        [SerializeField] private float _jumpForce = 2f;
        [SerializeField] private float _blendSpeed = 4f;

        public void Move(Vector2 axis)
        {
            _isGrounded = Physics.CheckSphere(transform.position, 0.25f, _groundMask);
            _anim.SetBool("IsGrounded", _isGrounded);
            _hor = Mathf.Lerp(_hor, axis.x, _blendSpeed * Time.deltaTime);
            _ver = Mathf.Lerp(_ver, axis.y, _blendSpeed * Time.deltaTime);
            _moveVector = _hor * _moveSpeed * transform.right + _ver * _moveSpeed * transform.forward;
            _cc.Move(_moveVector * Time.deltaTime);
            _anim.SetFloat("Horizontal", _hor);
            _anim.SetFloat("Vertical", _ver);
            if (_isGrounded && _velocity.y < -10f)
            {
                _velocity.y = -2f;
            }
            else
            {
                _velocity.y += _gravity * Time.deltaTime;
            }
            _cc.Move(_velocity * Time.deltaTime);
        }

        public void Jump(bool inputEnabled)
        {
            if (_isGrounded && inputEnabled)
            {
                _velocity.y = Mathf.Sqrt(_jumpForce * -2f * _gravity);
            }
        }
    }
}