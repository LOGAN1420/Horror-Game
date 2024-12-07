using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Transform slotsParent;
    [SerializeField] private GameObject slotPrefab;   
    
    private List<InventorySlotUI> slots = new List<InventorySlotUI>();
    private bool isInventoryOpen = false;

    private void Start()
    {
        // Initialize UI slots
        var inventory = InventoryManager.Instance.GetInventory();
        foreach (var slot in inventory)
        {
            CreateSlotUI();
        }

        // Subscribe to inventory changes
        InventoryManager.Instance.OnInventoryChanged += UpdateUI;
    }

    private void CreateSlotUI()
    {
        GameObject slotGO = Instantiate(slotPrefab, slotsParent);
        InventorySlotUI slotUI = slotGO.GetComponent<InventorySlotUI>();
        slots.Add(slotUI);
    }

    public void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        
        if (isInventoryOpen)
        {
            UIManager.Instance.ShowPanel(UIManager.Instance.InventoryPanel);
            UpdateUI();
        }
        else
        {
            UIManager.Instance.HidePanel(UIManager.Instance.InventoryPanel);
        }
    }

    private void UpdateUI()
    {
        var inventory = InventoryManager.Instance.GetInventory();
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < inventory.Count)
            {
                slots[i].UpdateSlot(inventory[i]);
            }
        }
    }
}
