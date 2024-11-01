using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour
{

    [Header("Select Button")]
    public GameObject NewGameButton;
    public GameObject LoadGameButton;
    public GameObject HowToPlayButton;
    public GameObject ExitButton;
    public GameObject OtionButton;

    [Header("Select UI")]
    public GameObject HowToPlayUI;
    public GameObject OptionUI;

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

        if (OtionButton == null)
            HowToPlayUI = GameObject.Find("HowToPlayUI");

        if (HowToPlayUI == null)
            HowToPlayUI = GameObject.Find("HowToPlayUI");
        
        if (OptionUI == null)
            OptionUI = GameObject.Find("OptionUI");

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
    public void OnOptionButton()
    {
        OptionUI.SetActive(true);
    }

    public void OnExitButton()
    {
        Debug.Log("게임종료");
        //Application.Quit();
    }

    public void CloseUI()
    {
        HowToPlayUI.SetActive(false);
        OptionUI.SetActive(false);
    }
}
