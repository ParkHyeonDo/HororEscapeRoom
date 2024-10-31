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
        //인스턴스.ItemData = data;
        //인스턴스.addItem?.Invoke();
        Destroy(gameObject);
    }

}
