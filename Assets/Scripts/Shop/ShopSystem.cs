using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public static ShopSystem Instance;
    
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private List<ItemSlot> _inventorySlots;
    [SerializeField] private List<Item> _itemsToSell;
	
    private CoinSystem _coinSystem;
    private Inventory _inventory;
    
    public GameObject ShopPanel => _shopPanel;

    void Awake ()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        _coinSystem = CoinSystem.Instance;
        _inventory = Inventory.Instance;
        InitializeSellItems();
    }

    public void OpenShop(bool open)
    {
        _shopPanel.SetActive(open);
        InitializeSellItems();
    }
	
    public void InitializeSellItems ()
    {
        for (int i = 0; i < _inventorySlots.Count; i++)
        {
            _inventorySlots[i].AddItem(_itemsToSell[i]);
        }
    }
	
    public void BuyItem(Item item)
    {
        if (_coinSystem.CanAffordItem(item.ItemBuyPrice))
        {
            _coinSystem.RemoveCoins(item.ItemBuyPrice);
            _inventory.Add(item);
            InitializeSellItems();
        }
        else
        {
            Debug.Log("Not enough coins");
        }
    }
}
