using UnityEngine;

namespace WinterUniverse
{
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField] private Transform _head;
        [SerializeField] private float _sens = 50f;
        [SerializeField] private float _angleLimit = 75f;
        private float _hor, _ver, _xRot;

        public void Look(Vector2 axis)
        {
            _hor = axis.x * _sens * Time.deltaTime;
            _ver = axis.y * _sens * Time.deltaTime;
            _xRot -= _ver;
            _xRot = Mathf.Clamp(_xRot, -_angleLimit, _angleLimit);
            _head.localRotation = Quaternion.Euler(_xRot, 0f, 0f);
            transform.Rotate(Vector3.up * _hor);
        }
    }
}