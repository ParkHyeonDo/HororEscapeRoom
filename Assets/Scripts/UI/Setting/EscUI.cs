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
    public GameObject SelectUI;
    public GameObject SettingUI;
    public GameObject HintUI;

    void Start()
    {
        if (HintButton == null)
            HintButton = GameObject.Find("HintButton");

        if (ContinueButton == null)
            ContinueButton = GameObject.Find("ContinueButton");

        if (SettingButton == null)
            SettingButton = GameObject.Find("SettingButton");

        if (MainMenuButton == null)
            MainMenuButton = GameObject.Find("MainMenuButton");

        if (ExitButton == null)
            ExitButton = GameObject.Find("ExitButton");

        if (SelectUI == null)
            SelectUI = GameObject.Find("EscUI");

        if (SettingUI == null)
            SettingUI = GameObject.Find("SettingUI");

        if (HintUI == null)
            HintUI = GameObject.Find("HintUI");

        CloseUI();
    }
    public void OnHintButton()
    {
        SelectUI.SetActive(false);
        HintUI.SetActive(true);
    }

    public void OnContinueButton()
    {
        SelectUI.SetActive(false);
    }
    public void OnSettingButton()
    {
        SelectUI.SetActive(false);
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
        SelectUI.SetActive(false);
    }

}
