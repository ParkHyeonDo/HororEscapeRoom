using UnityEngine;

[CreateAssetMenu(fileName = "InteractableObject", menuName = "Door", order = 1)]
public class Door : InteractableData
{
    [SerializeField] private Animator animator;
}
