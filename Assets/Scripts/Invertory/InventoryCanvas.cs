using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private Transform _itemsParent;
    [SerializeField] private List<ItemSlot> _itemSlotsList = new List<ItemSlot>();

    private Inventory _inventory;

    void Start()
    {
        _inventory = Inventory.Instance;
        _inventory.OnItemChangedCallback += UpdateUI;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenInventory(!_inventoryPanel.activeSelf);
        }
    }
	
    public void OpenInventory(bool open)
    {
        _inventoryPanel.SetActive(open);
        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < _itemSlotsList.Count; i++)
        {
            if (i < _inventory._itemsList.Count)
            {
                _itemSlotsList[i].AddItem(_inventory._itemsList[i]);
            } else
            {
                _itemSlotsList[i].ClearSlot();
            }
        }
    }
}
