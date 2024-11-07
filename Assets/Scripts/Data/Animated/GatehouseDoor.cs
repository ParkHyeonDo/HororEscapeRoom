using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GatehouseDoor", menuName = "New AnimatedObject/GatehouseDoor", order = 0)]
public class GatehouseDoor : Door
{
    public override void Temp()
    {
        if(QuestManager.Instance.CurQuestIndex == 0)
        {
            Debug.Log("Äù½ºÆ® 0 ¿Ï·á");
            base.Temp();
            QuestManager.Instance.QuestClearCheck(0);
        }
        
    }
}

