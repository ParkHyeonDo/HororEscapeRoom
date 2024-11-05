using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class InteractableObject: MonoBehaviour, IInteractable
{
    public InteractableData Data;
    public HintUI hintUI;
    public int noteIndex;

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
        Data.Interact();
    }

    public virtual void Temp()
    {
        Data.Temp();
    }
}