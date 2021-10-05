using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _radius = 2, _power = 5;
 [SerializeField] private AudioSource _audioSource;

    private Collider[] overlapResults = new Collider[10];
    private Coroutine _coroutine;
    
    private void OnEnable()
    {
       _coroutine = StartCoroutine(AutoExplode());
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemies = Overlap(_radius);
        if (enemies.Length == 0) return;
        
        StopCoroutine(_coroutine);
        _particleSystem.transform.parent = null;
        _particleSystem.Play();
        _audioSource.Play();
        foreach (var enemy in enemies)
        {
            var dir = transform.position - enemy.transform.position;
            dir = dir.normalized * _power;
            enemy.GetComponent<Rigidbody>().AddForce(dir, ForceMode.Impulse);
        }
        
        transform.parent.localScale = Vector3.zero;
        Destroy(gameObject.transform.parent.gameObject, 1); 
    }
 
    private Collider[] Overlap(float radius)
    {
        List<Collider> enemies = new List<Collider>();

        int numFounds = Physics.OverlapSphereNonAlloc(transform.position, _radius, overlapResults);
        for (int i = 0; i < numFounds; i++)
        {
            if (overlapResults[i].CompareTag("Enemy"))
            {
                enemies.Add(overlapResults[i]);
            }
            
        }

        var results = new Collider[enemies.Count];
        for (int i = 0; i < enemies.Count; i++)
        {
            results[i] = enemies[i];
        }

        return results;
    }

    IEnumerator AutoExplode()
    {
        ;
        yield return new WaitForSeconds(3);

        _particleSystem.transform.parent = null;
        _particleSystem.Play();
        Destroy(gameObject.transform.parent.gameObject ); 
        yield return null;
    }
}
