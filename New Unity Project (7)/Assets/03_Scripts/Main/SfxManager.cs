using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    private bool isSfxMute = false;

    public AudioClip click, back, wrong, check;
    
    private AudioSource audioSource;
    
    private static SfxManager instance;
    public static SfxManager Instance
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
        if (isSfxMute)
        {
            // 음소거 해제
            PlayerPrefs.SetInt("isSfxMute", 0);
        }
        else
        {
            PlayerPrefs.SetInt("isSfxMute", 1);
        }
        isSfxMute = !isSfxMute;
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
    
    public void playWrong()
    {
        if (!isSfxMute)
        {
            audioSource.clip = wrong;
            audioSource.Play();    
        }
    }

    public void playCheck()
    {
        if (!isSfxMute)
        {
            audioSource.clip = check;
            audioSource.Play();    
        }
    }
    
    public bool getIsSfxMute()
    {
        return isSfxMute;
    }

    public void setIsSfxMute(bool isSfxMute)
    {
        this.isSfxMute = isSfxMute;
    }
}
