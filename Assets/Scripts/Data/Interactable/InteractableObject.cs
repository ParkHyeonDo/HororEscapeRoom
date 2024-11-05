using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    public InteractableData Data;
    public HintUI hintUI; // Hint UI 참조
    public int noteIndex; // 이 객체가 사용하는 노트의 인덱스

    private void Start()
    {
        if (hintUI == null)
        {
            hintUI = FindObjectOfType<HintUI>();
        }
    }

    public string GetPrompt()
    {
        return $"<b>{Data.ObjectName}</b>\n{Data.Description}";
    }

    public virtual void Interact()
    {
        if (hintUI != null)
        {
            hintUI.AddNote(noteIndex, Data.ObjectName, Data.Content);
            hintUI.DisplayHint(noteIndex);
        }
    }
}
