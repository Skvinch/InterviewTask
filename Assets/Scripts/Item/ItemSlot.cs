using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image _itemIcon;
    [SerializeField] private Button _itemRemoveButton;
    [SerializeField] private Button _itemUseButton;
    [SerializeField] bool _isEquipmentSlot;
    
    private Item _item;
    
    private void Start()
    {
        if (_isEquipmentSlot)
        {
            _itemUseButton.onClick.AddListener(UnclotheItem);
        }
    }
    
    public void AddItem(Item newItem)
    {
        _item = newItem;
    
        _itemIcon.sprite = _item.ItemIcon;
        _itemIcon.enabled = true;
        _itemRemoveButton.interactable = true;
    }
    
    public void BuyItem()
    {
        if (CoinSystem.Instance.CanAffordItem(_item.ItemBuyPrice))
        {
            CoinSystem.Instance.RemoveCoins(_item.ItemBuyPrice);
            Inventory.Instance.Add(_item);
            ClearSlot();
            Inventory.Instance.InventoryCanvas.UpdateUI();
        }
    }
	   
    public void SellItem()
    {
        CoinSystem.Instance.AddCoins(_item.ItemSellPrice);
        Inventory.Instance.Remove(_item);
        ClearSlot();
        Inventory.Instance.InventoryCanvas.UpdateUI();
    }
    public void ClearSlot()
    {
        _item = null;
    
        _itemIcon.sprite = null;
        _itemIcon.enabled = false;
        _itemRemoveButton.interactable = false;
    }
    
    public void UnclotheItem()
    {
        if (_isEquipmentSlot && _item != null)
        {
            EquipmentManager.Instance.UnClothe(EquipmentManager.Instance.ReturnSlotIndex(this));
            Inventory.Instance.InventoryCanvas.UpdateUI();
        }
    }
    public void RemoveItemFromInventory() => Inventory.Instance.Remove(_item);
    
    public void UseItem ()
    {
        if (_item != null && !ShopSystem.Instance.ShopPanel.activeSelf)
        {
            _item.Use();
        }
        else if (_item != null && ShopSystem.Instance.ShopPanel.activeSelf)
        {
            SellItem();
        }
    }
}
