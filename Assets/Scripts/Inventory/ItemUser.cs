using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUser : MonoBehaviour
{
    [SerializeField] private AllVariantsItemSO collection;
    [SerializeField] private string[] healthItems;
    [SerializeField] private HealthManager _healthManager;
    public void UseItem(string itemName)
    {
        foreach (var item in healthItems)
        {
            if (itemName == item)
            {
                int key = collection.keys.IndexOf(itemName);
                _healthManager.AddHealth(collection.values[key].Value);
            }
        }
        
        /*switch (itemName)
        {
            case "Small_Potion":
            {
                int key = collection.keys.IndexOf(itemName);
                _healthManager.AddHealth(collection.values[key].Value);
                break;
            }
            case "Medium_Potion":
            {
                break;
            }
            case "Large_Potion":
            {
                break;
            }
        }*/
    }
}
