using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        QuestManager.Instance.QuestUI = this;
    }

    public void SetText(string text)
    {
        Text.text = text;
    }
}
