using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public ItemData ItemData;

    public string GetPrompt()
    {
        return $"<b>{ItemData.DisplayName}</b>\n{ItemData.Description}";
    }

    public void Interact()
    {
        ItemData.Interact();
    }
}