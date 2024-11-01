using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    public InteractableData Data;

    public string GetPrompt()
    {
        return $"<b>{Data.ObjectName}</b>\n{Data.Description}";
    }

    public virtual void Interact()
    {
        Data.Interact();
    }
}