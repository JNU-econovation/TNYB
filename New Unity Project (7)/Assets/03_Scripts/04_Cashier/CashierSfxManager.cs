using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashierSfxManager : MonoBehaviour
{
    private bool isSfxMute = false;

    public AudioClip scanner, click, back, Count, CountOver;
    
    private AudioSource audioSource;
    
    private static CashierSfxManager instance;
    public static CashierSfxManager Instance
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
        
//        DontDestroyOnLoad(gameObject);
        
        audioSource = GetComponent<AudioSource>();
    }

    public void clickSfxMute()
    {
        if (SfxManager.Instance.getIsSfxMute())
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

    public void playScoreCount()
    {
        if (!SfxManager.Instance.getIsSfxMute())
        {
            audioSource.loop = true;
            audioSource.clip = Count;
            audioSource.Play();  
        }
    }
    
    public void playCountOver()
    {
        if (!SfxManager.Instance.getIsSfxMute())
        {
            audioSource.loop = false;
            audioSource.clip = CountOver;
            audioSource.Play();  
        }
    }

    public void playScanner()
    {
        if (!SfxManager.Instance.getIsSfxMute())
        {
            audioSource.clip = scanner;
            audioSource.Play();    
        }
    }
    
    public void playBack()
    {
        if (!SfxManager.Instance.getIsSfxMute())
        {
            audioSource.clip = back;
            audioSource.Play();    
        }
    }
    
    public void playClick()
    {
        if (!SfxManager.Instance.getIsSfxMute())
        {
            audioSource.clip = click;
            audioSource.Play();    
        }
    }
}
