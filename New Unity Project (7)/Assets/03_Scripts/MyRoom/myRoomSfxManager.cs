using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myRoomSfxManager : MonoBehaviour
{
    private bool isSfxMute;

    public AudioClip click, back, ok, beep, wrong;
    private AudioSource audioSource;
    
    private static myRoomSfxManager instance;
    public static myRoomSfxManager Instance
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
        
        if (PlayerPrefs.GetInt("isSfxMute", 0) == 1)
        {
            isSfxMute = true;
        }
        else
        {
            isSfxMute = false;
        }
    }

    public void clickSfxMute()
    {
        if (!isSfxMute)
        {
            PlayerPrefs.SetInt("isSfxMute", 1);
            PlayerPrefs.Save();
            isSfxMute = true;
        }
        else
        {
            PlayerPrefs.SetInt("isSfxMute", 0);
            PlayerPrefs.Save();
            isSfxMute = false;
            playClick();
        }
    }
    
    public void playBack()
    {
        if (!isSfxMute)
        {
            audioSource.clip = back;
            audioSource.Play();    
        }
    }
    
    public void playClick()
    {
        if (!isSfxMute)
        {
            audioSource.clip = click;
            audioSource.Play();    
        }
    }
    
    public void playOk()
    {
        if (!isSfxMute)
        {
            audioSource.clip = ok;
            audioSource.Play();    
        }
    }
    
    public void playBeep()
    {
        if (!isSfxMute)
        {
            audioSource.clip = beep;
            audioSource.Play();    
        }
    }
    
    public void playWrong()
    {
        if (!isSfxMute)
        {
            audioSource.clip = wrong;
            audioSource.Play();    
        }
    }

    public bool getIsSfxMute()
    {
        return isSfxMute;
    }
}
