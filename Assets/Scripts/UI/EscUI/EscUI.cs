using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscUI : MonoBehaviour
{

    [Header("Button")]
    public GameObject SelectButton;
    public GameObject HintButton;
    public GameObject ContinueButton;
    public GameObject SettingButton;
    public GameObject MainMenuButton;
    public GameObject ExitButton;

    [Header("UI")]
    public GameObject ESCUI;
    public GameObject SettingUI;
    public GameObject HintUI;
    public GameObject WarningUI;

    void Start()
    {
        if (SelectButton == null)
            SelectButton = GameObject.Find("SelectButton");

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

        if (WarningUI == null)
            WarningUI = GameObject.Find("WarningUI");

        HintUI.SetActive(false);
        SettingUI.SetActive(false);
        WarningUI.SetActive(false);
        ESCUI.SetActive(false);
    }

    public void OnHintButton()
    {
        SelectButton.SetActive(false);
        HintUI.SetActive(true);
        PauseState();
    }

    public void OnContinueButton()
    {
        ESCUI.SetActive(false);
        SelectButton.SetActive(true);

        var playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.UpdatePauseState(false);
        }
    }

    public void OnSettingButton()
    {
        SettingUI.SetActive(true);
        PauseState();
    }
    public void OnWarningUI()
    {
        Debug.Log("Returning to Main Menu...");
        PauseState();
        SceneManager.LoadScene("StartScene");
    }
    public void OnMainMenuButton()
    {
        SelectButton.SetActive(false);
        WarningUI.SetActive(true);
    }

    public void OnExitButton()
    {
        PauseState();
        Debug.Log("게임종료");
        //Application.Quit();
    }

    public void CloseUI(GameObject gameObjectToActivate)
    {
        // 전달된 UI를 활성화
        if (gameObjectToActivate != null)
        {
            gameObjectToActivate.SetActive(false);
            SelectButton.SetActive(true);
        }
    }
    void PauseState() 
    {
        var playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.UpdatePauseState(true);
        }
    }
}
