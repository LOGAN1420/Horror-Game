using UnityEngine;

public interface IInteractable
{
    string GetInteractionPrompt();
    void Interact(InteractionController interactor);
    float GetInteractionDistance();
    bool CanInteract();
}
