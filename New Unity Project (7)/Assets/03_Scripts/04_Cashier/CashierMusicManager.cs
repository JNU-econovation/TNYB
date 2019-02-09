using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashierMusicManager : MonoBehaviour
{   
    // Main Sounds
    public AudioClip mainMusic;
   
    public AudioSource audioSource;
    
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
    }

    private void Start()
    {
        audioSource.clip = mainMusic;
        audioSource.Play();
    }

    public void SwitchMute()
    {
        if (!audioSource.mute)
        {
            audioSource.volume = 0;    
        }
        else
        {
            audioSource.volume = 100;
        }
    }
}
