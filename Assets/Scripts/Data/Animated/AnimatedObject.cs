using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatedObject : MonoBehaviour, IInteractable
{
    protected Animator Animat;
    public AnimatedData Data;

    private void Start()
    {
        if(!TryGetComponent<Animator>(out Animator animator))
        {
            Animat = this.gameObject.AddComponent<Animator>();
        }
        else
        {
            Animat = this.gameObject.GetComponent<Animator>();
        }
    }
    public string GetPrompt()
    {
        return $"<b>{Data.ObjectName}</b>\n{Data.Description}";
    }

    public virtual void Interact()
    {
        Data.Interact(Animat);
    }

    public virtual void Temp()
    {
        if (Data.GetType() == typeof(Door) || Data.GetType() == typeof(AuditoryDoor))
        {
            Door data = (Door)Data;
            data.Temp();
        }
    }
}
