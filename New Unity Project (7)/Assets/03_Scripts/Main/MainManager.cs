using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

    public AudioClip clickSound, backSound;
    public GameObject mainPanel, playPanel;
    public GameObject settingPanel;
    public GameObject rankPanel;
    public Button soundButton, vibrationButton, musicButton;
    private bool sound= true, music = true, vibration = true;
    public Image buttonTrue, buttonFalse;
    public Camera mainCamera;
  
    // Use this for initialization
    void Start () {
        playPanel.SetActive(false);
        mainPanel.SetActive(true);
        settingPanel.SetActive(false);
        rankPanel.SetActive(false);
        Screen.SetResolution(1920, 1080, true);


    }
	
   void Update()
    {
        if (Application.platform == RuntimePlatform.Android) //백버튼 종료
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();

    }
    public void ClickPlay()
    {
        playPanel.SetActive(true);
        if (sound)
        {
            GetComponent<AudioSource>().clip = clickSound;
            GetComponent<AudioSource>().Play();
        }
    }
    public void ClosePlay()
    {
        playPanel.SetActive(false);
        if (sound)
        {
            GetComponent<AudioSource>().clip = backSound;
            GetComponent<AudioSource>().Play();
        }
    }
    public void ClickSetting()
    {
        mainPanel.SetActive(false);
        settingPanel.SetActive(true);
        if (sound)
        {
            GetComponent<AudioSource>().clip = clickSound;
            GetComponent<AudioSource>().Play();
        }
    }
    public void CloseSetting()
    {
        mainPanel.SetActive(true);
        settingPanel.SetActive(false);
        if (sound)
        {
            GetComponent<AudioSource>().clip = backSound;
            GetComponent<AudioSource>().Play();
        }
    }
    public void ClickRank()
    {
        mainPanel.SetActive(false);
        rankPanel.SetActive(true);
        if (sound)
        {
            GetComponent<AudioSource>().clip = clickSound;
            GetComponent<AudioSource>().Play();
        }
    }
    public void CloseRank()
    {
        mainPanel.SetActive(true);
        rankPanel.SetActive(false);
        if (sound)
        {
            GetComponent<AudioSource>().clip = backSound;
            GetComponent<AudioSource>().Play();
        }
    }
    public void SoundButton()
    {
        if (sound)
        {
          soundButton.GetComponent<Image>().sprite = buttonFalse.GetComponent<Image>().sprite;
            sound = false;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = buttonTrue.GetComponent<Image>().sprite;
            sound = true;
        }
           
    }
    public void MusicButton()
    {
        if (music)
        {
            musicButton.GetComponent<Image>().sprite = buttonFalse.GetComponent<Image>().sprite;
            music = false;
            mainCamera.GetComponent<AudioSource>().Stop();
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = buttonTrue.GetComponent<Image>().sprite;
            music = true;
            mainCamera.GetComponent<AudioSource>().Play();
            
        }
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
