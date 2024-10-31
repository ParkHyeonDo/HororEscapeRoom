using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConversationScreen : MonoBehaviour
{
    public TextMeshProUGUI Text;
    // Start is called before the first frame update

    public void SetText(string text)
    {
        Text.text = text;
    }
}
