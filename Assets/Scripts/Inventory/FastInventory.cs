using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 
    FastInventory : MonoBehaviour
{
    [SerializeField] private string[] FastEquipment = new string[3+1];
    [SerializeField] private KeyCode[] _keyCodesFast = new KeyCode[3+1]
        {KeyCode.Keypad0, KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3};
    [SerializeField] private GameObject m_fastSlotPrefab;
    [SerializeField] public Inventory m_inventoryManager;
     
    private GameObject[] _fastSlots;
    private Image[] _previewImages;
    private Text[] _amountTexts, _nameTexts;
    
    private Sprite _defaultSprite;
    
    
    private void Start()
    { 
        if (m_inventoryManager == null)
            m_inventoryManager = FindObjectOfType<Inventory>();
        m_inventoryManager._fastInventory = this;
        CreateSlots();
        DisplayVisual(FastEquipment[0], 0);
    }

    private void CreateSlots()
    {
        FastEquipment = new string[_keyCodesFast.Length]; 
        int n = FastEquipment.Length;
        _fastSlots = new GameObject[n];
        _previewImages = new Image[n];
        _amountTexts = new Text[n];
        _nameTexts = new Text[n];

        _fastSlots[0] = m_fastSlotPrefab;
        for (int i = 1; i < n; i++)
            _fastSlots[i] = Instantiate(m_fastSlotPrefab, transform);
       
        for (int i = 0; i < n; i++)
        {
            DropSlot dropSlot = _fastSlots[i].GetComponent<DropSlot>();
            _previewImages[i] = _fastSlots[i].transform.GetChild(0).GetComponent<Image>();
            _amountTexts[i] = _fastSlots[i].transform.GetChild(1).GetComponentInChildren<Text>();
            _nameTexts[i] = _fastSlots[i].transform.GetChild(2).GetComponent<Text>();
            dropSlot.i = i;
            dropSlot._fi = this;
            dropSlot.m_collection = m_inventoryManager.collection;
        } 
        _defaultSprite = _previewImages[0].sprite;          
    }
    
    private void Update()
    {
        for (var i = 0; i < _keyCodesFast.Length; i++)
        {
            if (Input.GetKeyDown(_keyCodesFast[i]))
            {
                m_inventoryManager.UseItem(FastEquipment[i]);
                DisplayVisual(FastEquipment[i], i);
            }
        }
    }
    
    internal void Drop(int p, string dropName)
    {
        if (dropName.Substring(0, 5) != "Slot_") return;
        // if(i < m_inventoryManager.FastEquipment.Length) return;
        string itemName = dropName.Substring(5, dropName.Length - 5);
        
        FastEquipment[p] = itemName;
        DisplayVisual(FastEquipment[p], p);
    }

    private void DisplayVisual(string itemName, int p)
    {
        if(itemName == null) return;
        int key = m_inventoryManager.collection.keys.IndexOf(itemName);
         
        if ( !m_inventoryManager.d_GetItemAmounts.ContainsKey(itemName)
            || m_inventoryManager.d_GetItemAmounts[itemName] <= 0)
        {
            _previewImages[p].sprite = _defaultSprite;
            _amountTexts[p].text = "0";
            _nameTexts[p].text = "Empty";
            FastEquipment[p] = "";
        }
        else
        {
            _previewImages[p].sprite = m_inventoryManager.collection.values[key].Icon;
            _amountTexts[p].text = m_inventoryManager.d_GetItemAmounts[itemName].ToString();
            _nameTexts[p].text = itemName;
        }
    }
    public void DisplayVisual()
    {
        for (var p = 0; p < FastEquipment.Length; p++)
        {
            DisplayVisual(FastEquipment[p], p); 
        }
    }
}
