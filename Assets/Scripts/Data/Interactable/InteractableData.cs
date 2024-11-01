using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableObject", menuName = "New InteractableObject/Default", order = 0)]
public class InteractableData : ScriptableObject
{
    public string ObjectName;
    public string Description;

    public virtual void Interact()
    {
        //상호작용 구현
    }
}
