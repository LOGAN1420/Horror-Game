using UnityEngine;

public class PickableItem : InteractableBase
{
    [SerializeField] private Item item;
    [SerializeField] private int amount = 1;
    
    public override string GetInteractionPrompt()
    {
        return $"Pick up {item.itemName}";
    }
    
    public override void Interact(InteractionController interactor)
    {
        if (InventoryManager.Instance.AddItem(item, amount))
        {
            Debug.Log($"Picked up {item.itemName}");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }
}
