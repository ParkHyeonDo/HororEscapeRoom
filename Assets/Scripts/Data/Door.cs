using UnityEngine;

[CreateAssetMenu(fileName = "InteractableObject", menuName = "New InteractableObject/Door", order = 1)]
public class Door : InteractableData
{
    [SerializeField] private Animator animator;
}
