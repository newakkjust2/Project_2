using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUser : MonoBehaviour
{
    [SerializeField] private BombThrower _bombThrower;
    [SerializeField] private Transform m_hands;

    [SerializeField] private Jump m_jumper;
    
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
 
        if (itemName.Substring(0,5) == "bomb ")
        {
            if (UseBomb(itemName)) return;
        }

        if (itemName.Substring(0, 6) == "jumper")
        {
            m_jumper.Use();
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

    private bool UseBomb(string itemName)
    {
        if (_bombThrower == null)
        {
            Debug.Log(" assign bombthrower, please");
            return true;
        }

        int key = collection.keys.IndexOf(itemName);
        var obj = collection.values[key].prefab;
        _bombThrower.gameObject.SetActive(true);
        _bombThrower.BombBody = Instantiate(obj, m_hands).GetComponent<Rigidbody>();
        _bombThrower.BombBody.transform.position = m_hands.position;
        return false;
    }
}
