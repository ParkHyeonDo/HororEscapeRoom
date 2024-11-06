using System;
using TMPro;
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
        if(Data.GetType() == typeof(Door))
        {
            Door data = (Door)Data;
            data.IsLock = false;
            data.IsOpen = false;
            Data = data;
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
}
