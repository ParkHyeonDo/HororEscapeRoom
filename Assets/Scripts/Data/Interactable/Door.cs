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

    private void OpenDoor()
    {
        if (IsLock == true)
        {
            //if(GameManager.Instance.Player.현재 아이템 == 키)
            //{
            //  IsLock = false;
            //  AudioManager.Instance.PlaySfx("LockedDoorOpen");
            //}
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

}