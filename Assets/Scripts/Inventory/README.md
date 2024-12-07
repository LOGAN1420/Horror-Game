# Inventory System Implementation Guide

## Overview
This inventory system provides a flexible and easy-to-use way to manage items in your horror game. It includes features like item pickup, storage, and UI display.

## Components

### 1. Item System
- **Item.cs**: ScriptableObject that defines item properties
  - Create new items: Right-click → Create → Inventory → Item
  - Properties:
    - Item Name
    - Icon
    - Description
    - Is Usable
    - Is Stackable
    - Max Stack Size

### 2. Core Scripts
- **InventoryManager.cs**: Manages the inventory logic
  - Handles adding/removing items
  - Manages inventory slots
  - Provides events for UI updates
  
- **InventoryUI.cs**: Handles inventory display
  - Shows/hides inventory panel
  - Updates slot displays
  - Handles item interaction

- **InventorySlotUI.cs**: Individual slot behavior
  - Displays item icon and amount
  - Handles click events
  - Shows item tooltips

### 3. Integration with UI System
- **UIManager.cs**: Manages all UI panels
  - Controls panel visibility
  - Handles panel transitions
  - Manages interaction prompts

## Setup Instructions

### 1. Canvas Setup
```
Canvas (Screen Space - Overlay)
├── HUD Panel
│   └── Interaction Prompt Text (TMP)
├── Inventory Panel
│   ├── Background Image
│   ├── Title Text (TMP)
│   └── Slots Grid (Grid Layout Group)
└── Note Panel
```

### 2. Prefab Creation
1. Create Slot Prefab:
   ```
   Slot Prefab
   ├── Background Image
   ├── Item Icon Image
   └── Amount Text (TMP)
   ```
2. Add InventorySlotUI component to the prefab
3. Set up references in the inspector

### 3. Manager Setup
1. Create an empty GameObject named "UI Manager"
2. Add UIManager script
3. Assign panel references:
   - HUD Panel
   - Inventory Panel
   - Note Panel
   - Interaction Prompt Text

### 4. Inventory Setup
1. Create an empty GameObject named "Inventory Manager"
2. Add InventoryManager script
3. Set inventory size in inspector
4. Add InventoryUI script to Inventory Panel
5. Assign references:
   - Slots Parent (Grid)
   - Slot Prefab

### 5. Creating Items
1. Right-click in Project window
2. Select Create → Inventory → Item
3. Fill in item details:
   - Name
   - Icon
   - Description
   - Stackable settings

### 6. Making Items Pickable
1. Add PickableItem component to game objects
2. Assign Item ScriptableObject
3. Set amount (default is 1)

## Usage

### Opening/Closing Inventory
- Press 'I' to toggle inventory (configurable in InventoryUI)
- Cursor is automatically shown/hidden
- Player movement is handled automatically

### Item Interaction
- Left-click: Use item (if usable)
- Right-click: Show description
- Items are automatically stacked if stackable

### Adding New Item Types
1. Create new Item ScriptableObject
2. Override Use() method if needed
3. Create prefab with PickableItem component
4. Assign the Item ScriptableObject

## Notes
- Inventory size is configurable in InventoryManager
- UI layout can be customized through Unity's UI system
- System integrates with existing interaction system
- Panels handle cursor and input states automatically

## Troubleshooting
1. Items not appearing in inventory:
   - Check PickableItem component references
   - Verify InventoryManager is in the scene
   - Check console for errors

2. UI not updating:
   - Verify all UI references are set
   - Check UIManager references
   - Ensure panels are properly assigned

3. Interaction not working:
   - Check InteractionController setup
   - Verify input system configuration
   - Check raycast settings
