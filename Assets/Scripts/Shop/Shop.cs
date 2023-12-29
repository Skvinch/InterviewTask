using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, IInteractable
{
    [field:SerializeField] public GameObject InteractVisual { get; set; }
    
    private ShopSystem _shopSystem;
    private Inventory _inventory;
    private EquipmentManager _equipmentManager;

    private void Start()
    {
        _shopSystem = ShopSystem.Instance;
        _inventory = Inventory.Instance;
        _equipmentManager = EquipmentManager.Instance;
    }

    public void Interact()
    {
        _shopSystem.OpenShop(!_shopSystem.ShopPanel.activeSelf);
        _inventory.InventoryCanvas.OpenInventory(true);
        _equipmentManager.OpenEquipment(false);
    }

    public void SetFocus(bool focus)
    {
        InteractVisual.SetActive(focus);
        if (focus == false)
        {
            _shopSystem.OpenShop(false);
            _inventory.InventoryCanvas.OpenInventory(false);
            _equipmentManager.OpenEquipment(false);
        }
    }
}
