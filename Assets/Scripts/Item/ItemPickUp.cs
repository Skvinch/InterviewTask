using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemPickUp : MonoBehaviour, IInteractable
{
    [field:SerializeField] public GameObject InteractVisual { get; set; }
    [SerializeField] private List<Item> _itemsList = new List<Item>();
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Item _item;

    private void Start()
    {
        _item = _itemsList.ElementAt(Random.Range(0, _itemsList.Count));
        
        _spriteRenderer.sprite = _item.ItemIcon;
    }

    void PickUp ()
    {
        Inventory.Instance.Add(_item);

        Destroy(gameObject);
    }

    public void Interact()
    {
        PickUp();
    }

    public void SetFocus(bool focus)
    {
        InteractVisual.SetActive(focus);
    }
}
