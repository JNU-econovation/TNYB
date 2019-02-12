using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class factorySfxManager : MonoBehaviour
{
    public AudioClip okay, count, over;
    private bool isSfxMute = false;
    private AudioSource audioSource;

    private static factorySfxManager instance;
    public static factorySfxManager Instance
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
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("isSfxMute", 0) == 1)
        {
            isSfxMute = true;
        }
        else
        {
            isSfxMute = false;
        }


    }

    public bool getisSfxMute()
    {
        return isSfxMute;
    }
    public void ClickSound()
    {
        audioSource.clip = okay;
        if (!isSfxMute)
            GetComponent<AudioSource>().Play();
    }

    public void ClickSoundBtn()
    {
        if (isSfxMute)
        {
            isSfxMute = false;
            PlayerPrefs.SetInt("isSfxMute", 0);
            PlayerPrefs.Save();

            //SoundManger 호출
        }
        else
        {
            isSfxMute = true;
            PlayerPrefs.SetInt("isSfxMute", 1);
            PlayerPrefs.Save();
        }
    }
    public void CountSound()
    {
        audioSource.clip = count;
        if (!isSfxMute)
            audioSource.Play();
    }
    public void GameOverSound()
    {

        audioSource.clip = over;
        if (!isSfxMute)
            audioSource.Play();
    }
}
