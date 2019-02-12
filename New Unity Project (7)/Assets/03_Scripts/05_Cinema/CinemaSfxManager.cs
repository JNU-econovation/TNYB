using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaSfxManager : MonoBehaviour
{
    private bool isSfxMute = false;

    public AudioClip correct, wrong, Count, CountOver;
    private AudioSource audioSource;

    private static CinemaSfxManager instance;
    
    public static CinemaSfxManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
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
        }
    }
    public void playScoreCount()
    {
        if (!isSfxMute)
        {
            audioSource.loop = true;
            audioSource.clip = Count;
            audioSource.Play();
        }
    }
    public void playCountOver()
    {
        if (!isSfxMute)
        {
            audioSource.loop = false;
            audioSource.clip = CountOver;
            audioSource.Play();
        }
    }
    public void playCorrect()
    {
        if (!isSfxMute)
        {
            audioSource.clip = correct;
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


