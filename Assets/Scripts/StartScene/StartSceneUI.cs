using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour
{

    [Header("Button")]
    public GameObject NewGameButton;
    public GameObject LoadGameButton;
    public GameObject HowToPlayButton;
    public GameObject ExitButton;
    public GameObject SettingButton;

    [Header("UI")]
    public GameObject HowToPlayUI;
    public GameObject SettingUI;

    void Start()

    {
        if (NewGameButton == null)
            NewGameButton = GameObject.Find("NewGameButton");

        if (LoadGameButton == null)
            LoadGameButton = GameObject.Find("LoadGameButton");

        if (HowToPlayButton == null)
            HowToPlayButton = GameObject.Find("HowToPlayButton");

        if (ExitButton == null)
            ExitButton = GameObject.Find("ExitButton");

        if (SettingButton == null)
            SettingUI = GameObject.Find("SettingUI");

        if (HowToPlayUI == null)
            HowToPlayUI = GameObject.Find("HowToPlayUI");
        
        if (SettingUI == null)
            SettingUI = GameObject.Find("SettingUI");

        CloseUI();
    }

    public void OnNewGameButton()
    {
        Debug.Log("NewGameButton");
        SceneManager.LoadScene("MainScene");
    }
    public void OnLoadGameButton()
    {
        Debug.Log("플레이어 정보불러오기");
    }
    public void OnHowToPlayButton()
    {
        HowToPlayUI.SetActive(true);
    }
    public void OnSettingButton()
    {
        SettingUI.SetActive(true);
    }

    public void OnExitButton()
    {
        Debug.Log("게임종료");
        //Application.Quit();
    }

    public void CloseUI()
    {
        HowToPlayUI.SetActive(false);
        SettingUI.SetActive(false);
    }
}
