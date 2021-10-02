using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public Image icon;
    public Text quantity, itemNameText;
    

    private Sprite _defaultSprite;
    
    private void Start()
    {
        if(icon != null)
            _defaultSprite = icon.sprite;
    }

    public void RefreshSlotUI(int itemQuantity, string itemName, AllVariantsItemSO collection)
    {
        int itemKey = collection.keys.IndexOf(itemName);
        ItemSO temp = collection.values[itemKey];
        icon.sprite = temp.Icon;
        gameObject.name = "Slot_" + itemName;
        quantity.text = itemQuantity.ToString();
        itemNameText.text = itemName;
    }

    public void RefreshSlotUI()
    {
        icon.sprite = _defaultSprite;
        quantity.text = String.Empty;
        itemNameText.text = "Empty";
        gameObject.name = "Slot Empty";
    }
}
