using UnityEngine;
using UnityEngine.Events;

public class ReadableNote : InteractableBase
{
    [SerializeField] private string noteTitle = "Note";
    [TextArea(3, 10)]
    [SerializeField] private string noteContent = "This is a mysterious note.";
    [SerializeField] private UnityEvent onNoteRead;
    
    private bool hasBeenRead = false;

    public override void Interact(InteractionController interactor)
    {
        // Display the note using the singleton instance
        if (NoteDisplay.Instance != null)
        {
            NoteDisplay.Instance.DisplayNote(noteTitle, noteContent);
            
            if (!hasBeenRead)
            {
                hasBeenRead = true;
                onNoteRead?.Invoke();
            }
        }
        else
        {
            Debug.LogError("NoteDisplay not found in the scene!");
        }
    }
}
