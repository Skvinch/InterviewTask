using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public Action OnItemChangedCallback;
    public InventoryCanvas InventoryCanvas;
    public List<Item> _itemsList = new List<Item>();
    
    [SerializeField] private int _space;

    void Awake ()
    {
        if (Instance == null) Instance = this;
    }

    public void Add(Item item)
    {
        if (item.ShowItemInInventory) 
        {
            if (_itemsList.Count >= _space) 
            {
                Debug.Log ("Not enough room.");
                return;
            }
            _itemsList.Add (item);

            OnItemChangedCallback?.Invoke();
        }
    }

    public void Remove(Item item)
    {
        Debug.Log("Remove");
        _itemsList.Remove(item);

        OnItemChangedCallback?.Invoke();
    }
}
