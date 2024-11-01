using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item/Consumable", order = 2)]
public class Consumable : ItemData
{
    public ItemEffect[] Effect;
}
