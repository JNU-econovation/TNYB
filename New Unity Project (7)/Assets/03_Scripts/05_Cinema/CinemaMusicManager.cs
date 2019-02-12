using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinemaMusicManager : MonoBehaviour
{
    public static bool isMusicMute = false;
    public AudioClip mainMusic;

    public Button MusicBtn;
    public Sprite btn_0;
    public Sprite btn_1;

    private AudioSource audioSource;
    private static CinemaMusicManager instance;
    public static CinemaMusicManager Instance
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
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = mainMusic;
        audioSource.Play();
        firstMusicMute();
    }
    public void stopMusic()
    {
        audioSource.Stop();
    }

    void Update()
    {
        if (isMusicMute)
        {
            audioSource.volume = 0;
        }
        else if (!isMusicMute)
        {
            audioSource.volume = 1f;
        }
    }
    public void ClickMusicMute()
    {
        if (!isMusicMute)
        {
            // 음소거 아닐때
            PlayerPrefs.SetInt("isMusicMute", 0);
            isMusicMute = true;
            MusicBtn.GetComponent<Image>().sprite = btn_0;
        }
        else
        {
            PlayerPrefs.SetInt("isMusicMute", 1);
            isMusicMute = false;
            MusicBtn.GetComponent<Image>().sprite = btn_1;
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
