using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class ItemSpawner : MonoBehaviour
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
                g.transform.position = new Vector3((float) Random.Range(-5, 5), 2, (float) Random.Range(-5, 5));
            }
        }
    }
}
