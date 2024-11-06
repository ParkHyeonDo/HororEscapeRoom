using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Door", menuName = "New AnimatedObject/Door", order = 0)]
public class Door : AnimatedData
{
    private Animator _animator;
    public bool IsLock = false;
    public bool IsOpen = false;

    public override void Interact(Animator animator)
    {
        base.Interact(animator);
        _animator = animator;
        if(IsOpen == true)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }

    public virtual void Temp()
    {
        UnlockDoor();
    }

    private void OpenDoor()
    {
        if (IsLock == true)
        {
            if (GameManager.Instance.Player.HandItemData?.GetType() == typeof(Key))
            {
                IsLock = false;
                AudioManager.Instance.PlaySfx("LockedDoorOpen");
                _animator.SetBool("isLock",IsLock);
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
            _animator.SetBool("isOpen", IsOpen);
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
            _animator.SetBool("isOpen", IsOpen);
            return;
        }
    }
    private void UnlockDoor()
    {
        if (IsLock == true) 
        {
            IsLock = false;
        }
    }
}