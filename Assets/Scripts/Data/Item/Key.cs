using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item/Key", order = 3)]
public class Key : ItemData
{
    private string Tag;

    public override void Interact()
    {
        // 키 상호작용 구현
    }
}