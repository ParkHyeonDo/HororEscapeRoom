using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

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
        Destroy(gameObject);
    }
}