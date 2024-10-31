using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationUI : MonoBehaviour
{
    public ConversationScreen ConversationScreen;
    public bool IsConversation=false;
    // Start is called before the first frame update
    void Start()
    {
        /*CharacterManager.Instance.Player.ConversationUI = this*/
        ConversationScreen.gameObject.SetActive(false);
    }

    public void OnConversation(string text)
    {
        ConversationScreen.gameObject.SetActive(true);
        ConversationScreen.SetText(text);
        IsConversation = true;
    }

    public void CloseConversation()
    {
        ConversationScreen.gameObject.SetActive(false);
        IsConversation = false;
    }
}
