using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public int i; 
    public FastInventory _fi;
    public AllVariantsItemSO m_collection;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            string dropName = eventData.pointerDrag.gameObject.name; 
            _fi.Drop(i, dropName); 
        }
    }
}
