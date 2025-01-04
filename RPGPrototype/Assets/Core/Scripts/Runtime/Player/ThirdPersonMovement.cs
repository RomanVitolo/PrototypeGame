using System;
using InputSystem.GlobalInputs.Scripts;
using UnityEngine;

namespace Core.Runtime
{
    public class ThirdPersonMovement : MonoBehaviour
    {
        [field: SerializeField] public InputReaderSO InputReaderSo { get; set; }

        [SerializeField] private Rigidbody _rb;
        [SerializeField] private Animator _anim;
        
        [SerializeField] private float _turnSpeed = 50f;
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _dampTime;

        private Vector3 _velocity;

        void Awake()
        {
            InputReaderSo.InitializeControls();
            _rb = GetComponent<Rigidbody>();
            _anim = GetComponentInChildren<Animator>();
        }

        void OnDestroy()
        {
            InputReaderSo.DestroyControls();
        }
       
        void Update()
        {
            transform.Rotate(0, InputReaderSo.AimInputValue.x * Time.deltaTime * _turnSpeed, 0);
            
            _velocity = new Vector3(InputReaderSo.MovementValue.x, 0, InputReaderSo.MovementValue.y);
            float xVelocity = Vector3.Dot(_velocity.normalized, transform.right);
            float zVelocity = Vector3.Dot(_velocity.normalized, transform.forward);
            
            
            
            _anim.SetFloat("xVelocity", xVelocity, _dampTime, Time.deltaTime);
            _anim.SetFloat("zVelocity", zVelocity, _dampTime, Time.deltaTime);
        }

        void FixedUpdate()
        {
            _velocity *= _moveSpeed * Time.fixedDeltaTime;
            var offset = transform.rotation * _velocity;
            _rb.MovePosition(transform.position + offset);
        }
    }
}
