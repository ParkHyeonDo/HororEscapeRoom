using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class InteractableObject: MonoBehaviour, IInteractable
{
    public InteractableData Data;
    public HintUI hintUI;
    public int noteIndex;
    public GameObject hintObject;

    private void Start()
    {
        if (hintUI == null)
        {
            hintUI = FindObjectOfType<HintUI>();
        }
    }
    public virtual string GetPrompt()
    {
        return $"<b>{Data.ObjectName}</b>\n{Data.Description}";
    }

    public virtual void Interact()
    {
        if (Data.isHint && hintObject != null)
        {
            Data.Interact();
            hintObject.SetActive(false);
        }
        if (hintUI != null)
        {
            hintUI.AddNote(noteIndex, Data.ObjectName, Data.Content, Data.isHint);
            hintUI.DisplayHint(noteIndex);
            Data.Interact();
        }
        Data.Interact();
    }

    public virtual void Temp()
    {
        Data.Temp();
    }
}