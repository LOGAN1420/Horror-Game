# Horror Game Interaction System

A modular interaction system for Unity horror games that handles player interactions with various objects like items, notes, and other interactables.

## System Components

### 1. Core Scripts
- `IInteractable.cs`: Interface that defines the contract for all interactable objects
- `InteractableBase.cs`: Base class for all interactable objects
- `InteractionController.cs`: Main controller that handles player's interaction with objects
- `PickableItem.cs`: Example implementation for pickable items
- `ReadableNote.cs`: Example implementation for readable notes/documents

## Setup Instructions

### 1. Input System Setup
1. Open your Input Actions asset (typically `InputSystem_Actions`)
2. Add a new Action called "Interact"
   - Set the binding to the 'E' key (or your preferred key)
   - Make sure it's set to "Button" type
3. In the Player Input component on your player:
   - Add the new "Interact" action to the action events
   - Map it to `OnInteract` function

### 2. UI Setup
1. In your Canvas, create a new UI Text element for interaction prompts:
   ```
   Canvas
   └── InteractionPrompt (TextMeshProUGUI)
   ```
2. Position the prompt where you want it to appear (typically center-bottom of screen)
3. Make sure to use TextMeshProUGUI component for better text rendering

### 3. Player Setup
1. Add the `InteractionController` script to your player character
2. In the Inspector, configure:
   - Assign the Main Camera to "Camera Transform"
   - Assign the prompt TextMeshProUGUI component to "Prompt Text"
   - Set the "Interaction Layer" to the layer you'll use for interactable objects
   - Adjust "Raycast Distance" as needed (default: 2f)

### 4. Making Objects Interactable

#### For Pickable Items:
1. Add the `PickableItem` component to your object
2. Set the object's layer to your interaction layer
3. Configure in Inspector:
   - Item Name
   - Item Description
   - Item Icon (optional)
   - Interaction Prompt (inherited from InteractableBase)
   - Interaction Distance (inherited from InteractableBase)

#### For Readable Notes:
1. Add the `ReadableNote` component to your object
2. Set the object's layer to your interaction layer
3. Configure in Inspector:
   - Note Title
   - Note Content (supports multiple lines)
   - On Note Read Events (Unity Events triggered when note is first read)
   - Interaction Prompt (inherited from InteractableBase)
   - Interaction Distance (inherited from InteractableBase)

## Creating New Interactable Types

1. Create a new script that inherits from `InteractableBase`
2. Implement the `Interact` method
3. Add any additional properties or functionality needed

Example:
```csharp
public class CustomInteractable : InteractableBase
{
    [SerializeField] private string customProperty;

    public override void Interact(InteractionController interactor)
    {
        // Your custom interaction logic here
        Debug.Log($"Custom interaction with {customProperty}");
    }
}
```

## Usage Tips

1. Layer Setup:
   - Create a dedicated layer for interactable objects (e.g., "Interactable")
   - Assign this layer to all interactable objects
   - Set this layer in the InteractionController's Interaction Layer mask

2. Testing:
   - Use the included PickableItem and ReadableNote components as examples
   - Check the console for debug messages when interacting
   - Make sure the interaction prompt appears when looking at interactable objects

3. Best Practices:
   - Keep interaction distances reasonable (2-3 units recommended)
   - Write clear, informative interaction prompts
   - Use meaningful names for items and notes
   - Consider adding sound effects for interactions

## Extending the System

The system is designed to be modular and expandable. You can:
1. Add inventory integration to PickableItem
2. Create a proper UI system for displaying note contents
3. Add new types of interactions (doors, switches, etc.)
4. Implement sound effects and visual feedback
5. Add interaction animations
