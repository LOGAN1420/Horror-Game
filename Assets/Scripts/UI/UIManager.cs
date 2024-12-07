using UnityEngine;
using TMPro;
using StarterAssets;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI Panels")]
    [SerializeField] private GameObject notePanel;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject hudPanel;

    [Header("Other UI Scripts")]
    [SerializeField] private InventoryUI inventoryUI;

    [Header("HUD Elements")]
    [SerializeField] private TextMeshProUGUI ItemNameText;
    [SerializeField] private GameObject interactionIcon;

    [Header("Settings")]
    [SerializeField] private KeyCode inventoryKey = KeyCode.I;
    [SerializeField] private bool ShouldDisableMovement = true;
    [SerializeField] private bool ShouldDisableCamera = true;
   
    private bool IsMovementEnabled = true;
    private bool IsLookEnabled = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }        
    }

    private void Start()
    {
        // Initialize all panels to their default states
        if (notePanel) notePanel.SetActive(false);
        if (inventoryPanel) inventoryPanel.SetActive(false);
        if (hudPanel) hudPanel.SetActive(true);
        if (ItemNameText) ItemNameText.text = "";
        if (interactionIcon) interactionIcon.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(inventoryKey))
        {
            inventoryUI.ToggleInventory();
        }
    }

    public void ShowPanel(GameObject panel)
    {
        // Hide other panels that shouldn't be visible together
        if (panel == inventoryPanel)
        {
            if (notePanel) notePanel.SetActive(false);
        }
        else if (panel == notePanel)
        {
            if (inventoryPanel) inventoryPanel.SetActive(false);
        }

        panel.SetActive(true);

        // Disable player input when showing UI panels
        DisablePlayerInput();
    }

    public void HidePanel(GameObject panel)
    {
        panel.SetActive(false);

        // Only enable player input if no other panels are open
        if (!IsAnyPanelOpen())
        {
            EnablePlayerInput();
        }
    }

    private void DisablePlayerInput()
    {
        if (ShouldDisableMovement) IsMovementEnabled = false;
        if(ShouldDisableCamera) IsLookEnabled = false;

        // Show cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;        
    }

    private void EnablePlayerInput()
    {
        IsMovementEnabled = true;
        IsLookEnabled = true;

        // Hide and lock cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;       
    }

    public bool IsPanelVisible(GameObject panel)
    {
        return panel && panel.activeSelf;
    }

    public void UpdateInteractionPrompt(string text)
    {
        if (ItemNameText)
        {
            ItemNameText.text = text;
        }
        if (interactionIcon)
        {
            if (text == "")
            {
                interactionIcon.SetActive(false);
            }
            else
            {
                interactionIcon.SetActive(true);
            }
        }
    }

    public bool IsAnyPanelOpen()
    {
        return (notePanel && notePanel.activeSelf) ||
               (inventoryPanel && inventoryPanel.activeSelf);
    }

    public GameObject NotePanel => notePanel;
    public GameObject InventoryPanel => inventoryPanel;
    public GameObject HUDPanel => hudPanel;
    public bool _IsMovementEnabled => IsMovementEnabled;
    public bool _IsLookEnabled => IsLookEnabled;
}
