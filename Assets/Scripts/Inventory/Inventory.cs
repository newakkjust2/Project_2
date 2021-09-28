using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public FastInventory _fastInventory;
    public AllVariantsItemSO collection;

    [SerializeField] private Button slotPrefab;
    [SerializeField] private RectTransform container;
    [SerializeField] private GameObject inventoryFull;
    [SerializeField] private ItemUser itemUser;
    
    private LinkedList<string> ll_Items = new LinkedList<string>();
    private Dictionary<string, int> d_ItemAmounts = new Dictionary<string, int>();

    public Dictionary<string, int> d_GetItemAmounts
    {
        get => d_ItemAmounts;
    }
    // UI
    private List<Button> l_slotButtons = new List<Button>();
    private List<SlotUI> l_slotUIs = new List<SlotUI>();
    private Coroutine _coroutineHandler;
    

    private void Start()
    {
        CreateTwelveSlots();
        UpdateUI();
        
    }
    private void CreateTwelveSlots()
    {
        for (int i = 0; i < 12; i++)
        {
            l_slotButtons.Add(Instantiate(slotPrefab, container));  
            l_slotUIs.Add(l_slotButtons[i].GetComponent<SlotUI>());
        }
        slotPrefab.gameObject.SetActive(false);
    }
    public void UpdateUI()
    {
        foreach (var slots in l_slotUIs)
        {
            slots.UpdateUI();
        }
        
        int index = 0;
        foreach (var itemName in ll_Items)
        {
            int k = collection.keys.IndexOf(itemName);
            l_slotUIs[index].UpdateUI(d_ItemAmounts[itemName], itemName, collection);
            l_slotButtons[index].onClick.RemoveAllListeners();
            l_slotButtons[index].onClick.AddListener(()=>UseItem(itemName));
            l_slotButtons[index].gameObject.name = "Slot_" + itemName;
            index++;
        }
        if (ll_Items.Count < 6)
        {
            for (int i = 6; i < 12; i++)
            {
                l_slotButtons[i].gameObject.SetActive(false);
            }
        }
        else
        {
            for (int i = 6; i < 12; i++)
            {
                l_slotButtons[i].gameObject.SetActive(true);
            }
        }
        
    }
    public bool AddItem(string itemData)
    {
        
        if (!collection.keys.Contains(itemData))
        {
            return false;
        }
        
        if (ll_Items.Count > 12)
        {
            if (_coroutineHandler == null)
            {
                _coroutineHandler = StartCoroutine(InventoryFullCoRoutine());
            }
            return false;
        }

        if (!ll_Items.Contains(itemData))
        {
            ll_Items.AddLast(itemData);
            d_ItemAmounts.Add(itemData, 0);
        }

        d_ItemAmounts[itemData]++;
        UpdateUI();
        return true;
    }
    
    public bool UseItem(string itemName)
    {
        if (ll_Items.Contains(itemName))
        {
            d_ItemAmounts[itemName]--;
            if (d_ItemAmounts[itemName] <= 0)
            {
                ll_Items.Remove(itemName);
                d_ItemAmounts.Remove(itemName);
            }
            // GameObject g = Instantiate(collection.prefab);
            // g.GetComponent<Weapon>().WeaponItemAction();
            itemUser.UseItem(itemName);
            UpdateUI();
            _fastInventory.DisplayVisual(itemName);
            return true;
        }
        return false;
    }
    
    IEnumerator InventoryFullCoRoutine()
    {
        inventoryFull.SetActive(true);
        yield return new WaitForSeconds(1f);
        inventoryFull.SetActive(false);
        _coroutineHandler = null;
    }
}
