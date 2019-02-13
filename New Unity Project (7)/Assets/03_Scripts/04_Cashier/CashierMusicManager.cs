using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashierMusicManager : MonoBehaviour
{
    private bool isMusicMute;
    public AudioClip mainMusic;

    public Button MusicBtn;
    public Sprite btn_0;
    public Sprite btn_1;

    private AudioSource audioSource;
    
    private static CashierMusicManager instance;
    public static CashierMusicManager Instance
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
        
        audioSource = GetComponent<AudioSource>();
        
        if (PlayerPrefs.GetInt("isMusicMute", 0) == 1)
        {
            isMusicMute = true;
        }
        else
        {
            isMusicMute = false;
        }
    }

    private void Start()
    {
        audioSource.clip = mainMusic;
        audioSource.Play();
        firstMusicMute();
    }
    
    public void stopMusic()
    {
        audioSource.Stop();
    }

    private void FixedUpdate()
    {
        if (isMusicMute)
        {
            audioSource.volume = 0;
        }
        else if(!isMusicMute)
        {
            audioSource.volume = 0.8f;    
        }
    }

    //public void ClickMusicMute()
    //{
    //    if (!isMusicMute)
    //    {
    //        // 음소거 아닐때
    //        PlayerPrefs.SetInt("isMusicMute", 1);
    //        PlayerPrefs.Save();
    //        isMusicMute = true;
    //    }
    //    else
    //    {
    //        PlayerPrefs.SetInt("isMusicMute", 0);
    //        PlayerPrefs.Save();
    //        isMusicMute = false;
    //    }
    //}

    public bool getIsMusicMute()
    {
        return isMusicMute;
    }

    public void ClickMusicMute()
    {
        if (!isMusicMute)
        {
            // 음소거 아닐때
            PlayerPrefs.SetInt("isMusicMute", 0);
            isMusicMute = true;
            MusicBtn.GetComponent<Image>().sprite = btn_0;
            audioSource.volume = 0;
        }
        else
        {
            PlayerPrefs.SetInt("isMusicMute", 1);
            isMusicMute = false;
            MusicBtn.GetComponent<Image>().sprite = btn_1;
            audioSource.volume = 0.8f;
        }
        PlayerPrefs.Save();
    }

    public void firstMusicMute()
    {
        if (isMusicMute)
        {
            MusicBtn.GetComponent<Image>().sprite = btn_0;
        }
        else
        {
            MusicBtn.GetComponent<Image>().sprite = btn_1;
        }
    }
}
