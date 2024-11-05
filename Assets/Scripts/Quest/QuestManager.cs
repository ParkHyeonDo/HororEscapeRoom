using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;
    public static QuestManager Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = new GameObject("QuestManager").AddComponent<QuestManager>();
            }
            return instance;

        }
    }

    public QuestUI QuestUI;
    [SerializeField]
    public List<QuestData> QuestDataList;

    public int CurQuestIndex;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CurQuestIndex = 0;
        QuestUIUpdate();
    }

    public void QuestUIUpdate()
    {
        QuestUI.SetText("Quest : "+QuestDataList[CurQuestIndex].QuestContent);
    }

    public bool QuestClearCheck(int questID)
    {
        if(questID == QuestDataList[CurQuestIndex].QuestId)
        {
            CurQuestIndex++;
            QuestUIUpdate();
            return true;
        }
        return false;
    }
}
