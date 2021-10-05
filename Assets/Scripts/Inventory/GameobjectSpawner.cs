using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class GameobjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Prefabs;
    [SerializeField] private KeyCode spawnKeyCode = KeyCode.S;

    private void Update()
    {
        if (Input.GetKeyDown(spawnKeyCode))
        {
            foreach (var VARIABLE in Prefabs)
            {
                GameObject g = Instantiate(VARIABLE);
                g.transform.position = new Vector3((float) 
                    transform.position.x + Random.Range(-5, 5), 
                    transform.position.y + Random.Range(-0.1f, 0.2f), 
                    transform.position.z + Random.Range(-5, 5));
            }
        }
    }
}
