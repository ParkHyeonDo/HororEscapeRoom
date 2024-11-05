using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConversationScreen : MonoBehaviour
{
    public TextMeshProUGUI Text;
    // Start is called before the first frame update

    public GameObject SetText(string text)
    {
        GameObject gameObject = this.gameObject;
        Text.text = text;
        return gameObject;
    }
}
