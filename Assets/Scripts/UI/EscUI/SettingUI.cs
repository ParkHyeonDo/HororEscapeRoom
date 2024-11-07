using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour
{
    public GameObject SettingScreen;
    // Start is called before the first frame update
    void Start()
    {
        /*GameManager.Instance.SettingUI = this*/
    }

    // Update is called once per frame
    public void OnSetting()
    {
        SettingScreen.SetActive(true);
    }
}
