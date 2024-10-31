using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    public string GetInteractPrompt();

    public void OnInteracrt();
}
public class ItemObject : MonoBehaviour , IInteractable
{
    public ItemData data;

    public string GetInteractPrompt()
    {
        string str = $"{data.DisplayName}\n{data.Description}";
        return str ;
    }

    public void OnInteracrt()
    {
        //�ν��Ͻ�.ItemData = data;
        //�ν��Ͻ�.addItem?.Invoke();
        Destroy(gameObject);
    }

}
