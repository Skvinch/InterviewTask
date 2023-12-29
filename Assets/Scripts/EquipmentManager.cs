using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
	public static EquipmentManager Instance;
	
	[SerializeField] private ItemEquipment[] DefaultWear;
	[SerializeField] private List<ItemSlot> _equipmentSlots;
	[SerializeField] private ItemEquipment[] _currentEquipment;
	[SerializeField] private PlayerEquipmentSlots[] _currentVisualSlotsArray;
	[SerializeField] private GameObject _equipmentPanel;
	
	public delegate void OnEquipmentChanged(ItemEquipment newItem, ItemEquipment oldItem);
	public event OnEquipmentChanged onEquipmentChanged;

	private Inventory _inventory;

	void Awake ()
	{
		if (Instance == null) Instance = this;
	}
	
	void Start ()
	{
		_inventory = Inventory.Instance;

		int numSlots = System.Enum.GetNames(typeof(ItemEquipment.EquipmentType)).Length;
		_currentEquipment = new ItemEquipment[numSlots];
		
		EquipAllDefault ();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.U))
		{
			_equipmentPanel.SetActive(!_equipmentPanel.activeSelf);
		}
	}

	public void OpenEquipment(bool open) => _equipmentPanel.SetActive(open);
	
	public int ReturnSlotIndex(ItemSlot slot) => _equipmentSlots.IndexOf(slot);
	
	public void Equip(ItemEquipment newItem)
	{
		ItemEquipment oldItem = null;

		int slotIndex = (int)newItem.EquipmentSlot;

		if (_currentEquipment[slotIndex] != null)
		{
			oldItem = _currentEquipment [slotIndex];

			_inventory.Add (oldItem);
		}
		
		onEquipmentChanged?.Invoke(newItem, oldItem);

		_currentEquipment[slotIndex] = newItem;
		_equipmentSlots[slotIndex].AddItem(newItem);

		if (newItem.ItemIcon != null) 
		{
			AttachToMesh(newItem.EquipmentSpritesList, slotIndex);
		}
	}

	public void UnClothe(int slotIndex)
	{
		if (_currentEquipment[slotIndex] != null)
		{
			ItemEquipment oldItem = _currentEquipment[slotIndex];
			_inventory.Add(oldItem);
			_equipmentSlots[slotIndex].ClearSlot();
			_currentEquipment[slotIndex] = DefaultWear[slotIndex];
			
			onEquipmentChanged?.Invoke(null, oldItem);
			
			Equip(DefaultWear[slotIndex]);
		}
	}

	void UnClotheAll()
	{
		for (int i = 0; i < _currentEquipment.Length; i++)
		{
			UnClothe(i);
		}
		EquipAllDefault ();
	}

	private void EquipAllDefault()
	{
		foreach (ItemEquipment itemEquipment in DefaultWear)
		{
			Equip(itemEquipment);
		}
	}

	void AttachToMesh(Sprite[] sprite, int slotIndex) 
	{
		for (int i = 0; i < _currentVisualSlotsArray[slotIndex].EquipmentSlotRenderersList.Count; i++)
		{
			_currentVisualSlotsArray[slotIndex].EquipmentSlotRenderersList[i].sprite = sprite[i];
		}
	}
}
