using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeedModifier = 4f;
    //   [SerializeField] private PoolProjectiles _projectilePool;
    public Rigidbody _rb;
    private Vector3 _shootDirection;


    private void OnEnable()
    {
        _rb.velocity = _shootDirection * projectileSpeedModifier;  
        Invoke(nameof(DestroySelf), 5f);
    }

    private void Update()
    {
        _rb.velocity = _shootDirection * projectileSpeedModifier; 
        //_rb.MoveRotation(new Quaternion());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<HealthManager>().TakeAwayHealth(10f);
        }
    }

    public void InitializeDirection(Vector3 dir)
    {
        _shootDirection = dir;
        transform.LookAt(transform.position + dir);
        transform.Rotate(new Vector3(90,0,0));
        transform.position += Vector3.up * 1.2f;
    }

    void DestroySelf()
    {
        gameObject.SetActive(false);
    }
}