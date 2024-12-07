using UnityEngine;

public abstract class InteractableBase : MonoBehaviour, IInteractable
{
    [SerializeField] protected string ItemName = "Press E to interact";
    [SerializeField] protected float interactionDistance = 2f;
    
    public virtual string GetInteractionPrompt()
    {
        return ItemName;
    }

    public abstract void Interact(InteractionController interactor);

    public virtual float GetInteractionDistance()
    {
        return interactionDistance;
    }

    public virtual bool CanInteract()
    {
        return true;
    }
}
