using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Jump : Usable
{ 
    [SerializeField] private Vector3 force = new Vector3(0, 5, 1);
    [SerializeField] private Rigidbody user;
     
    [SerializeField] private AudioSource _audioSource;
    
    public override void Use()
    {
         user.AddForce(force, ForceMode.Impulse);
         if (_audioSource = null)
             _audioSource = GetComponent<AudioSource>();
         _audioSource.Play();

    }
}
