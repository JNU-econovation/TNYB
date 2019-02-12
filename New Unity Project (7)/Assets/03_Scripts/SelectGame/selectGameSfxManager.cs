using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectGameSfxManager : MonoBehaviour
{
    private bool isSfxMute;

    public AudioClip click, back, start, next;
    
    private AudioSource audioSource;
    
    private static selectGameSfxManager instance;
    public static selectGameSfxManager Instance
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
            // 음소거 해제
            PlayerPrefs.SetInt("isSfxMute", 1);
            PlayerPrefs.Save();
            isSfxMute = true;
        }
        else
        {
            PlayerPrefs.SetInt("isSfxMute", 0);
            PlayerPrefs.Save();
            isSfxMute = true;
        }
    }
    
    public void playNext()
    {
        if (!isSfxMute)
        {
            audioSource.clip = next;
            audioSource.Play();    
        }
    }
    
    public void playStart()
    {
        if (!isSfxMute)
        {
            audioSource.clip = start;
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
    
    public void playBack()
    {
        if (!isSfxMute)
        {
            audioSource.clip = back;
            audioSource.Play();    
        }
    }
}
