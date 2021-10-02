using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text quantity; 
    [SerializeField] private Sprite _defaultSprite;
     
    public void RefreshSlotUI(int itemQuantity, string itemName, AllVariantsItemSO collection)
    {
        int itemKey = collection.keys.IndexOf(itemName);
        ItemSO temp = collection.values[itemKey];
        icon.sprite = temp.Icon;
        gameObject.name = itemName;
        quantity.text = itemQuantity.ToString();
    }

    public void RefreshSlotUI()
    {
        icon.sprite = _defaultSprite;
        quantity.text = String.Empty;
        gameObject.name = "Slot Empty";
    }
}
