using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class myRoomMusicManager : MonoBehaviour
{
    private bool isMusicMute;
    public AudioClip myRoomMusic;
   
    private AudioSource audioSource;
    
    private static myRoomMusicManager instance;
    public static myRoomMusicManager Instance
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
        
        DontDestroyOnLoad(gameObject);      
    }

    private void Start()
    {
        audioSource.clip = myRoomMusic;
        audioSource.Play();
    }
    
    public void stopMusic()
    {
        audioSource.Stop();
    }

    private void FixedUpdate()
    {
        switch (Application.loadedLevel)
        {
            case 0:
            case 2:
            case 3:
            case 4:
                Destroy(gameObject);
                break;
        }
        
        if (isMusicMute)
        {
            audioSource.volume = 0;
        }
        else if(!isMusicMute)
        {
            audioSource.volume = 0.8f;    
        }
    }

    public void ClickMusicMute()
    {
        if (!isMusicMute)
        {
            // 음소거 아닐때
            PlayerPrefs.SetInt("isMusicMute", 1);
            PlayerPrefs.Save();
            isMusicMute = true;
        }
        else
        {
            PlayerPrefs.SetInt("isMusicMute", 0);
            PlayerPrefs.Save();
            isMusicMute = false;
        }
    }

    public bool getIsMusicMute()
    {
        return isMusicMute;
    }
}
