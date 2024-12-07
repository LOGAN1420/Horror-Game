using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using StarterAssets;

public class InteractionController : MonoBehaviour
{
    [Header("Interaction Settings")]
    [SerializeField] private LayerMask interactionLayer;
    [SerializeField] private float maxInteractionDistance = 2f;
    [SerializeField] private Transform mainCamera;
    
    [Header("UI")]
    [SerializeField] private StarterAssets.StarterAssetsInputs starterAssetsInputs;
    
    private IInteractable currentInteractable;

    private void Awake()
    {
        if (mainCamera == null)
        {
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
                this.mainCamera = mainCamera.transform;
        }
        if(starterAssetsInputs == null)
        {
            starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        }
    }

    private void Update()
    {
        // Check for interactable objects
        if (Physics.Raycast(mainCamera.position, mainCamera.forward, out RaycastHit hit, maxInteractionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            
            if (interactable != null && interactable.CanInteract())
            {
                currentInteractable = interactable;
                float distance = Vector3.Distance(transform.position, hit.point);
                
                if (distance <= interactable.GetInteractionDistance())
                {
                    // Show interaction prompt in HUD
                    UIManager.Instance.UpdateInteractionPrompt(interactable.GetInteractionPrompt());
                    
                    // Check for interaction input
                    if (starterAssetsInputs.interact)
                    {
                        interactable.Interact(this);
                        starterAssetsInputs.interact = false;
                    }
                }
                else
                {
                    UIManager.Instance.UpdateInteractionPrompt("");
                }
            }
            else
            {
                currentInteractable = null;
                UIManager.Instance.UpdateInteractionPrompt("");
            }
        }
        else
        {
            currentInteractable = null;
            UIManager.Instance.UpdateInteractionPrompt("");
        }
    }
}
