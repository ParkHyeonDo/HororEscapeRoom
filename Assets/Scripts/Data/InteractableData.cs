using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableObject", menuName = "Default", order = 0)]
public class InteractableData : ScriptableObject
{
    public string ObjectName;
    public string Description;
}
