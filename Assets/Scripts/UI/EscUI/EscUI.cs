using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscUI : MonoBehaviour
{

    [Header("Button")]
    public GameObject HintButton;
    public GameObject ContinueButton;
    public GameObject SettingButton;
    public GameObject MainMenuButton;
    public GameObject ExitButton;


    [Header("UI")]
    public GameObject ESCUI;
    public GameObject SettingUI;
    public GameObject HintUI;

    void Start()
    {
        if (HintButton == null)
            HintButton = GameObject.Find("Hint");

        if (ContinueButton == null)
            ContinueButton = GameObject.Find("Continue");

        if (SettingButton == null)
            SettingButton = GameObject.Find("Setting");

        if (MainMenuButton == null)
            MainMenuButton = GameObject.Find("MainMenu");

        if (ExitButton == null)
            ExitButton = GameObject.Find("Exit");

        if (ESCUI == null)
            ESCUI = GameObject.Find("ESCUI");

        if (SettingUI == null)
            SettingUI = GameObject.Find("SettingUI");

        if (HintUI == null)
            HintUI = GameObject.Find("HintUI");

        CloseUI();
    }
    public void OnHintButton()
    {
        ESCUI.SetActive(false);
        HintUI.SetActive(true);
    }

    public void OnContinueButton()
    {
        ESCUI.SetActive(false);
    }
    public void OnSettingButton()
    {
        ESCUI.SetActive(false);
        SettingUI.SetActive(true);
    }

    public void OnMainMenuButton()
    {
        Debug.Log("Returning to Main Menu...");
        SceneManager.LoadScene("StartScene");
    }
    public void OnExitButton()
    {
        Debug.Log("게임종료");
        //Application.Quit();
    }

    public void CloseUI()
    {
        HintUI.SetActive(false);
        SettingUI.SetActive(false);
        ESCUI.SetActive(false);
    }

}
