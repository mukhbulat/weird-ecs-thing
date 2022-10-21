using System;
using UnityEngine;

namespace Client.UnityComponents
{
    [RequireComponent(typeof(Rigidbody))]
    public class UsualObject : MonoBehaviour
    {
        [SerializeField] private Vector3 _direction = Vector3.one;
        [SerializeField] private float _speed = 1;
        
        private Rigidbody _rigidbody;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            var motion = _direction * _speed * Time.deltaTime;
            _rigidbody.MovePosition(transform.position + motion);
        }
    }
}