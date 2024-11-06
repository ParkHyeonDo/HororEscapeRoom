using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public bool[] Items;//맵 상 아이템 enable, disable 목록
    public string[] Slots;//퀵슬롯의 아이템 목록
    public int[] SlotsStack;//아이템 쌓인 갯수
    public int QuestIndex;//진행중이던 퀘스트 번호. 이에 따라 문 열림 닫힘 적용
    public List<int> Notes;//획득한 노트 목록
    public List<string> NoteNames;
    public List<string> NoteContents;
    public bool[] DoorState;

}
public class SaveAndLoad : Singleton<SaveAndLoad>
{
    private string _path;
    
    // Start is called before the first frame update
    void Start()
    {
        _path = Path.Combine(Application.dataPath, "data.json");
    }

    public void Load()
    {
        SaveData saveData = new SaveData();
        if (!File.Exists(_path))
        {
            return;
        }
        string loadJson = File.ReadAllText(_path);
        saveData = JsonUtility.FromJson<SaveData>(loadJson);
        if (saveData != null)
        {
            /*Set data into right place*/
            QuestManager.Instance.CurQuestIndex = saveData.QuestIndex;
            QuestManager.Instance.QuestUIUpdate();
            GameManager.Instance.Player.QuickSlot.LoadItem(saveData.Slots,saveData.SlotsStack);
            HintUI hintUI = GameObject.Find("UICanvas").transform.Find("ESCUI").transform.Find("HintUI").GetComponent<HintUI>();
            int a = 0;
            foreach(int noteIndex in saveData.Notes)
            {
                hintUI.hintDictionary.Add(noteIndex, (saveData.NoteNames[a], saveData.NoteContents[a]));
                a++;
            }
            GameManager.Instance.ItemManager.LoadItemState(saveData.Items);
            GameManager.Instance.DoorManager.SetDoorState(saveData.DoorState);
        }    
    }

    public void Save()
    {
        SaveData saveData = new SaveData();
        /*Input data to save in saveData*/
       
        saveData.Items = GameManager.Instance.ItemManager.GetItemState();
        saveData.QuestIndex = QuestManager.Instance.CurQuestIndex;
        saveData.Slots = GameManager.Instance.Player.QuickSlot.GetSlotItemName();
        saveData.SlotsStack = GameManager.Instance.Player.QuickSlot.GetSlotItemStack();
        HintUI hintUI = GameObject.Find("UICanvas").transform.Find("ESCUI").transform.Find("HintUI").GetComponent<HintUI>();
        foreach (var element in hintUI.hintDictionary) 
        {
            saveData.Notes.Add(element.Key);
            saveData.NoteNames.Add(element.Value.noteName);
            saveData.NoteContents.Add(element.Value.content);
        }
        saveData.DoorState = GameManager.Instance.DoorManager.GetDoorState();
        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(_path, json);
    }
}
