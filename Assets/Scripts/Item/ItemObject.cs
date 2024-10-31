using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    public string InteractPrompt();

    public void OnInteracrt();
}
public class ItemObject : MonoBehaviour , IInteractable
{
    public ItemData Data;

    public string InteractPrompt()
    {
        string str = $"{Data.DisplayName}\n{Data.Description}";
        return str ;
    }

    public void OnInteracrt()
    {
        //�ν��Ͻ�.ItemData = data;
        //�ν��Ͻ�.addItem?.Invoke();
        Destroy(gameObject);
    }


    
}
