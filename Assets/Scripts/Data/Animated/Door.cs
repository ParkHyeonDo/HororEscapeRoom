using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Door", menuName = "New AnimatedObject/Door", order = 0)]
public class Door : AnimatedData
{
    private Animator _animator;
    private Key _key;
    [SerializeField] private int DoorTag;
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
                _key = (Key)GameManager.Instance.Player.HandItemData;
                if (_key.Tag  ==  DoorTag)
                {
                    IsLock = false;
                    AudioManager.Instance.PlaySfx("LockedDoorOpen");
                    _animator.SetBool("isLock", IsLock);
                    GameManager.Instance.Player.QuickSlot.RemoveItem();
                    _key = null;
                    if (QuestManager.Instance.CurQuestIndex == 0)
                    {
                        Debug.Log("퀘스트 0 완료");
                        QuestManager.Instance.QuestClearCheck(0);
                    }
                    GameManager.Instance.Player.HandItemData = null;
                    return;
                }
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