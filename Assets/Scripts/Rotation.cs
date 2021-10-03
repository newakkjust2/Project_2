using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform _transform;
    
    void Start()
    {
        if (_transform == null) _transform = GetComponent<Transform>();
    }
 
    void Update()
    {
       _transform.Rotate(Vector3.forward * speed * Time.deltaTime); 
    }
}
