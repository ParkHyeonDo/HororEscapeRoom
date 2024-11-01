using UnityEngine;

[CreateAssetMenu(fileName = "InteractableObject", menuName = "New InteractableObject/Door", order = 1)]
public class Door : InteractableData
{
    [SerializeField] private Animator animator;

    public override void Interact()
    {
        //문 상호작용 구현
    }
}