using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon = null;
    [TextArea(3, 10)]
    public string description = "";
    public bool isUsable = false;
    public bool isStackable = false;
    public int maxStackSize = 1;

    public virtual void Use()
    {
        // Called when item is used
        Debug.Log($"Using {itemName}");
    }
}
