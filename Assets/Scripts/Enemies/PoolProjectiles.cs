using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class PoolProjectiles : MonoBehaviour
{
    private Projectile _projectile;
    private int _poolIndex;
    [SerializeField] private int poolSize = 25;
    [SerializeField] private List<Projectile> pooledObjects = new List<Projectile>();
    [SerializeField] private GameObject projectilePrefab;

    private void Start()
    {
        FillPool();
    }

    private void FillPool()
    {
        for(int i = 0; i < poolSize; i++)
        {
            pooledObjects.Add(Instantiate( projectilePrefab).GetComponent<Projectile>());
            pooledObjects[i].gameObject.SetActive(false);
            pooledObjects[i]._rb =  pooledObjects[i].GetComponent<Rigidbody>();
        }
    }

    public void Shoot()
    {
        pooledObjects[_poolIndex].transform.localPosition = transform.position;
        pooledObjects[_poolIndex].gameObject.SetActive(true);
        pooledObjects[_poolIndex].InitializeDirection(transform.forward);
        _poolIndex++;
        if (_poolIndex >= poolSize)
            _poolIndex = 0;
    }
}


