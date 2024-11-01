using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<ItemObject> Items;
    public ItemSlot[] Slots;
    public int QuestIndex;
}
public class SaveAndLoad : MonoBehaviour
{
    private string _path;
    public List<Item> StartItems;
    // Start is called before the first frame update
    void Start()
    {
        _path = Path.Combine(Application.dataPath, "data.json");
        Load();
    }

    public void Load()
    {
        SaveData saveData = new SaveData();

        if (!File.Exists(_path))
        {
            /*start data set*/
            /*ItemManager.Instance.ItemList = StartItems;*/;
        }
        else
        {
            string loadJson = File.ReadAllText(_path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);
            if (saveData != null)
            {
                /*Set data into right place*/
                QuestManager.Instance.CurQuestIndex = saveData.QuestIndex;
                QuestManager.Instance.QuestUIUpdate();
                /*QuickSlot.Instance.Slots = saveData.Slots;*/
            }
        }
    }

    public void Save()
    {
        SaveData saveData = new SaveData();
        /*Input data to save in saveData*/
        /*
        saveData.Items = ItemManager.Instance.ItemList;
        saveData.QuestIndex = QuestManager.Instance.CurQuestIndex;
        saveData.Slots = QuickSlot.Instance.Slots;
        */
        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(_path, json);
    }
}
