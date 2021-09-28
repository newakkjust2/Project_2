using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public Image icon;
    public Text quantity;

    private Sprite _defaultSprite;
    
    private void Start()
    {
        if(icon != null)
            _defaultSprite = icon.sprite;
    }

    public void UpdateUI(int itemQuantity, string itemName, AllVariantsItemSO collection)
    {
        int itemKey = collection.keys.IndexOf(itemName);
        ItemSO temp = collection.values[itemKey];   
        if(icon != null)
            icon.sprite = temp.Icon;
        else
        {
            Debug.Log("Icon in collection is null");
        }
        quantity.text = itemQuantity.ToString();
        
    }

    public void UpdateUI()
    {
        icon.sprite = _defaultSprite;
        quantity.text = String.Empty;
    }
}
