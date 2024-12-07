using UnityEngine;
using TMPro;
using UnityEngine.UI;
using StarterAssets;

public class NoteDisplay : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI contentText;
    
    private bool isDisplaying = false;
    private static NoteDisplay instance;
    private bool wasMovementEnabled;
    private bool wasLookEnabled;
    private bool wasCursorLocked;

    private void Awake()
    {
        instance = this;
    }

    public static NoteDisplay Instance
    {
        get { return instance; }
    }

    public void DisplayNote(string title, string content)
    {
        titleText.text = title;
        contentText.text = content;
        UIManager.Instance.ShowPanel(UIManager.Instance.NotePanel);
        isDisplaying = true;        
    }

    public void HideNote()
    {
        UIManager.Instance.HidePanel(UIManager.Instance.NotePanel);
        isDisplaying = false;        
    }

    private void Update()
    {
        if (isDisplaying)
        {

            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            {
                HideNote();
            }
        }
    }
}
