using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    
    [SerializeField] private int inventorySize = 20;
    private List<InventorySlot> inventorySlots;
    
    public event Action OnInventoryChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializeInventory();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeInventory()
    {
        inventorySlots = new List<InventorySlot>();
        for (int i = 0; i < inventorySize; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddItem(Item item, int amount = 1)
    {
        // Check for stackable items first
        if (item.isStackable)
        {
            var existingSlot = inventorySlots.Find(slot => 
                slot.item != null && 
                slot.item == item && 
                slot.amount < slot.item.maxStackSize);

            if (existingSlot != null)
            {
                existingSlot.amount += amount;
                OnInventoryChanged?.Invoke();
                return true;
            }
        }

        // Find empty slot
        var emptySlot = inventorySlots.Find(slot => slot.item == null);
        if (emptySlot != null)
        {
            emptySlot.item = item;
            emptySlot.amount = amount;
            OnInventoryChanged?.Invoke();
            return true;
        }

        Debug.Log("Inventory is full!");
        return false;
    }

    public void RemoveItem(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < inventorySlots.Count)
        {
            inventorySlots[slotIndex].Clear();
            OnInventoryChanged?.Invoke();
        }
    }

    public void UseItem(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < inventorySlots.Count)
        {
            var slot = inventorySlots[slotIndex];
            if (slot.item != null && slot.item.isUsable)
            {
                slot.item.Use();
                if (!slot.item.isStackable || slot.amount <= 1)
                {
                    RemoveItem(slotIndex);
                }
                else
                {
                    slot.amount--;
                    OnInventoryChanged?.Invoke();
                }
            }
        }
    }

    public List<InventorySlot> GetInventory()
    {
        return inventorySlots;
    }
}

[System.Serializable]
public class InventorySlot
{
    public Item item;
    public int amount;

    public void Clear()
    {
        item = null;
        amount = 0;
    }
}
