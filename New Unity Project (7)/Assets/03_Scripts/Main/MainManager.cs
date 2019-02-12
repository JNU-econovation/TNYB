using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public GameObject mainPanel, playPanel, settingPanel, rankPanel, signinPanel, exitPanel, signupPanel, nicknamePanel;
    public Button soundButton, vibrationButton, musicButton;
    private bool music = true, vibration = true;
    public Image buttonTrue, buttonFalse;

    private static MainManager instance;

    public static MainManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    // Use this for initialization
    void Start () {
        playPanel.SetActive(false);
        mainPanel.SetActive(false);
        settingPanel.SetActive(false);
        rankPanel.SetActive(false);
        exitPanel.SetActive(false);
        signinPanel.SetActive(true);
        signupPanel.SetActive(false);
        nicknamePanel.SetActive(false);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(Screen.width, (Screen.width * 16)/9, true);
    }
	
   void Update()
    {
        if (Application.platform == RuntimePlatform.Android) //백버튼 종료
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
    }
    public void ClickExit()
    {
        exitPanel.SetActive(true);
        SfxManager.Instance.playClick();
    }
    public void YesExit()
    {
        Application.Quit();
    }
    public void NoExit()
    {
        exitPanel.SetActive(false);
        SfxManager.Instance.playClick();
    }
    public void ClickPlay()
    {
        playPanel.SetActive(true);
        SfxManager.Instance.playClick();
    }
    public void ClosePlay()
    {
        playPanel.SetActive(false);
        SfxManager.Instance.playBack();
    }
    public void ClickSetting()
    {
//        mainPanel.SetActive(false);
        settingPanel.SetActive(true);
        SfxManager.Instance.playClick();
    }
    public void CloseSetting()
    {
//        mainPanel.SetActive(true);
        settingPanel.SetActive(false);
        SfxManager.Instance.playBack();
    }
    public void ClickRank()
    {
//        mainPanel.SetActive(false);
        rankPanel.SetActive(true);
        SfxManager.Instance.playClick();
    }
    public void CloseRank()
    {
        rankPanel.SetActive(false);
        SfxManager.Instance.playBack();
    }

    public void ClickStart()
    {
        SfxManager.Instance.playClick();
        signinPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void ClickLogOut()
    {
        SfxManager.Instance.playClick();
        signinPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void ClickSignUp()
    {
        SfxManager.Instance.playClick();
        signupPanel.SetActive(true);
        signinPanel.SetActive(false);
    }

    public void ClickSignUpBack()
    {
        SfxManager.Instance.playClick();
        signupPanel.SetActive(false);
        signinPanel.SetActive(true);
    }

    public void toSignInPanel()
    {
        SfxManager.Instance.playClick();
        signupPanel.SetActive(false);
        signinPanel.SetActive(true);
    }

    public void toMainPanel()
    {
        SfxManager.Instance.playClick();
        mainPanel.SetActive(true);
        nicknamePanel.SetActive(false);
        signinPanel.SetActive(false);
    }

    public void toNicknamePanel()
    {
        SfxManager.Instance.playClick();
        nicknamePanel.SetActive(true);
        signinPanel.SetActive(false);
    }

    public void VibrationButton()
    {
        if (vibration)
        {
            vibrationButton.GetComponent<Image>().sprite = buttonFalse.GetComponent<Image>().sprite;
            vibration = false;
        }
        else
        {
            vibrationButton.GetComponent<Image>().sprite = buttonTrue.GetComponent<Image>().sprite;
            vibration = true;
        }
    }
}
