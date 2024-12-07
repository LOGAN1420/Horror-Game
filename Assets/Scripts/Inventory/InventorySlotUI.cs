using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI amountText;
    [SerializeField] private GameObject selectedHighlight;
    
    private InventorySlot currentSlot;
    private int slotIndex;

    public void UpdateSlot(InventorySlot slot)
    {
        currentSlot = slot;
        
        if (slot.item != null)
        {
            iconImage.sprite = slot.item.icon;
            iconImage.enabled = true;
            amountText.text = slot.amount > 1 ? slot.amount.ToString() : "";
            amountText.enabled = slot.amount > 1;
        }
        else
        {
            iconImage.sprite = null;
            iconImage.enabled = false;
            amountText.text = "";
            amountText.enabled = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentSlot?.item != null)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                // Left click to use item
                if (currentSlot.item.isUsable)
                {
                    InventoryManager.Instance.UseItem(slotIndex);
                }
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                // Right click to show description or additional options
                Debug.Log($"Item Description: {currentSlot.item.description}");
            }
        }
    }

    public void SetIndex(int index)
    {
        slotIndex = index;
    }
}
