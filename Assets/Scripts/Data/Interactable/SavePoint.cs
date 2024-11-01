using UnityEngine;

[CreateAssetMenu(fileName = "InteractableObject", menuName = "New InteractableObject/SavePoint", order = 2)]
public class SavePoint : InteractableData
{
    public Transform PlayerTransform;
    //진행 상황 public bool[]
    //소지한 아이템 목록 public item[]

    public override void Interact()
    {
        //세이브 포인트 상호작용 구현
    }
}