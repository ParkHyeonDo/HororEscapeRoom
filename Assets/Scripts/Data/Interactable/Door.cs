using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableObject", menuName = "New InteractableObject/Door", order = 1)]
public class Door : InteractableData
{
    [SerializeField] private Animator animator;
    public bool IsLock;
    public bool IsOpen;

    public override void Interact()
    {
        OpenDoor();
        CloseDoor();
    }

    public override void Temp()
    {
        UnlockDoor();
    }

    private void OpenDoor()
    {
        if (IsLock == true)
        {
            if (GameManager.Instance.Player.ItemData?.GetType() == typeof(Key))
            {
                IsLock = false;
                AudioManager.Instance.PlaySfx("LockedDoorOpen");
                Destroy(GameManager.Instance.Player.ItemData.GameObject());
                return;
            }
            AudioManager.Instance.PlaySfx("DoorLocked");
            return;
        }
        else
        {
            //애니메이션 실행
            AudioManager.Instance.PlaySfx("OpenDoor");
            IsOpen = true;
            return;
        }
    }
    private void CloseDoor()
    {
        if (IsOpen == true)
        {
            //애니메이션 실행
            AudioManager.Instance.PlaySfx("CloseDoor");
            IsOpen = false;
            return;
        }
    }

    private void UnlockDoor()
    {
        if (IsLock == true) 
        {
            IsLock = false;
            Description = "unlocked";
        }
    }

}