using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public Sprite ItemIcon = null;
    public bool ShowItemInInventory = true;
    public int ItemSellPrice;
    public int ItemBuyPrice;

    public virtual void Use() {}

    protected void RemoveFromInventory()
    {
        Inventory.Instance.Remove(this);
    }
}
