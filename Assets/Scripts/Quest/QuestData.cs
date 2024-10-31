using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName ="New Quest", order = 1)]
public class QuestData : ScriptableObject
{
    public string QuestContent;
    public int QuestId;
}
