using UnityEngine;

[CreateAssetMenu(fileName = "InteractableObject", menuName = "New InteractableObject/Door", order = 1)]
public class Door : InteractableData
{
    [SerializeField] private Animator animator;

    public override void Interact()
    {
        Debug.Log("Locked");
    }

    private void OpenDoor()
    {

    }
    private void CloseDoor()
    {

    }

}