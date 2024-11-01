using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemObject : MonoBehaviour , IInteractable
{
    public ItemData Data;

    public string GetPrompt()
    {
        string str = $"{Data.DisplayName}\n{Data.Description}";
        return str ;
    }

    public void Interact()
    {
        GameManager.Instance.Player.ItemData = Data;
        GameManager.Instance.Player.AddItem?.Invoke();
        Destroy(gameObject);
    }


    
}
