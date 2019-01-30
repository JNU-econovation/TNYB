using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

    public GameObject mainPanel, playPanel, settingPanel, rankPanel, loginPanel, exitPanel;
    public Button soundButton, vibrationButton, musicButton;
    private bool music = true, vibration = true;
    public Image buttonTrue, buttonFalse;
  
    // Use this for initialization
    void Start () {
        playPanel.SetActive(false);
        mainPanel.SetActive(false);
        settingPanel.SetActive(false);
        rankPanel.SetActive(false);
        exitPanel.SetActive(false);
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
        loginPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
    
    public void SoundButton()
    {
        if (!SfxManager.Instance.getIsMute())
        {
            soundButton.GetComponent<Image>().sprite = buttonFalse.GetComponent<Image>().sprite;
            SfxManager.Instance.setIsMute(true);
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = buttonTrue.GetComponent<Image>().sprite;
            SfxManager.Instance.setIsMute(false);
        }
           
    }
    public void MusicButton()
    {
        if (!MusicManager.Instance.audioSource.mute)
        {
            musicButton.GetComponent<Image>().sprite = buttonFalse.GetComponent<Image>().sprite;
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = buttonTrue.GetComponent<Image>().sprite;
        }
        MusicManager.Instance.SwitchMute();
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
