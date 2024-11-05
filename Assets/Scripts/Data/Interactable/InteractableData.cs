using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableObject", menuName = "New InteractableObject/Default", order = 0)]
public class InteractableData : ScriptableObject
{
    public string ObjectName;
    [TextArea]
    public string Description;
    [TextArea(10, 20)]
    public string Content;
    public virtual void Interact()
    {
        Debug.Log("interact");
    }

    public virtual void Temp()
    {
        Debug.Log("");
    }
}