using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Player picking up item
    [SerializeField] ItemSO itemData;
    
    private void OnTriggerEnter(Collider other)
    {
//        Debug.Log("Hello from ONTRIGGERENTER");
        if (other.CompareTag("Player"))
        {
//            Debug.Log("Hello from ONTRIGGERENTER TAG CHECK");
            if (GlobalInventory.playerInventoryInstance.AddItem(itemData.ItemName))
            {
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("The item is not assigned in ");
            }
        }
    }
}
