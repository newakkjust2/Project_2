using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMover : MonoBehaviour
{
    [SerializeField] float _turnSpeed = 1000f;
    [SerializeField] float _moveSpeed = 5f;
    
    private Rigidbody _rigidbody;
    private Animator _animator; 
    private float _mouseMovement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        _mouseMovement += Input.GetAxis("Mouse X");
    }

    private void FixedUpdate()
    {

        transform.Rotate(0, _mouseMovement * Time.deltaTime * _turnSpeed, 0);
        _mouseMovement = 0f;
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            vertical *= 2f;
        }
        
        var velocity = new Vector3(horizontal, 0,vertical);
        velocity *= _moveSpeed * Time.fixedDeltaTime;
        Vector3 offset = transform.rotation * velocity;
        _rigidbody.MovePosition(transform.position + offset);
        
        _animator.SetFloat("Vertical", vertical, 0.1f, Time.deltaTime);
        _animator.SetFloat("Horizontal", horizontal, .1f, Time.deltaTime);
    }
}
