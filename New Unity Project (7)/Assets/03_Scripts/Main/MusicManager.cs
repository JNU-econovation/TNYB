using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private bool isMusicMute = false;
    public AudioClip mainMusic;
   
    public AudioSource audioSource;
    
    private static MusicManager instance;
    public static MusicManager Instance
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
    }
    
    public void ClickMusicMute()
    {
        if (!isMusicMute)
        {
            // 음소거 아닐때
            PlayerPrefs.SetInt("isMusicMute", 1);
            isMusicMute = true;
        }
        else
        {
            PlayerPrefs.SetInt("isMusicMute", 0);
            isMusicMute = false;
        }
    }
}
