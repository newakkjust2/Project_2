using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombThrower : MonoBehaviour
{ 
    public Rigidbody BombBody { get => _rb; set {  _rb = value;  b_charge = true; }  }
    private Rigidbody _rb;
    private bool b_charge;
    
    [SerializeField] private Vector3 direction;
    [SerializeField] private float power;
 
     
     void Update()
     { 
         if (Input.GetMouseButtonDown(0) && b_charge)
         {
             ThrowTheBomb();
         }
     }

     private void ThrowTheBomb()
     {
         b_charge = false;
         if (_rb == null) return;
         _rb.transform.parent = null;
         _rb.isKinematic = false;
         _rb.AddForce(direction * power, ForceMode.Impulse);
         _rb.transform.GetChild(1).gameObject.SetActive(true);
     }
}
