using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "AuditoryDoor", menuName = "New AnimatedObject/AuditoryDoor", order = 0)]
public class AuditoryDoor : Door
{
	public override void Temp()
	{
		if (QuestManager.Instance.CurQuestIndex == 1)
		{
			base.Temp();
			QuestManager.Instance.QuestClearCheck(1);
			IsLock = false;
		}
	}
}