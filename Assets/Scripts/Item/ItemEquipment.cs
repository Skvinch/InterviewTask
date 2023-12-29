using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/ItemEquipment")]
public class ItemEquipment : Item
{
    public EquipmentType EquipmentSlot;
    public Sprite[] EquipmentSpritesList;

    public override void Use()
    {
        EquipmentManager.Instance.Equip(this);
        RemoveFromInventory();
    }
    
    public enum EquipmentType{Head, Chest, Legs, Weapon}
}
