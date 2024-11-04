using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class InteractableObject: MonoBehaviour, IInteractable
{
    public InteractableData Data;
    private AudioSource _audioSource;

    private void Awake()
    {
        if(!TryGetComponent<AudioSource>(out _audioSource))
        {
            this.AddComponent<AudioSource>();
        }
    }

    public string GetPrompt()
    {
        return $"<b>{Data.ObjectName}</b>\n{Data.Description}";
    }

    public virtual void Interact()
    {
        Data.Interact();
        _audioSource?.Play();
    }
}