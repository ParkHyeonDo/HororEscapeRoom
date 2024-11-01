using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item/Equipable", order = 1)]
public class Equipable : ItemData
{
    public bool IsEquipped;

    public ItemEffect[] Effects;
}
