using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class factorySfxManager : MonoBehaviour
{
    public AudioClip okay, count, over;
    private bool isSfxMute = false;
    private AudioSource audioSource;

    public Sprite btnSprite1;
    public Sprite btnSprite2;
    public Button SoundBtn;

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
        if (PlayerPrefs.GetInt("isSfxMute", 0) == 1)
        {
            isSfxMute = true;
            // 음소거 이미지로 바꾸기
        }
        else
        {
            isSfxMute = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        FirstSoundBtn();


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
            SoundBtn.GetComponent<Image>().sprite = btnSprite2;
            //SoundManger 호출
        }
        else
        {
            isSfxMute = true;
            PlayerPrefs.SetInt("isSfxMute", 1);
            PlayerPrefs.Save();
            SoundBtn.GetComponent<Image>().sprite = btnSprite1;
        }
    }
    public void FirstSoundBtn()
    {
        if(isSfxMute)
        {
            SoundBtn.GetComponent<Image>().sprite = btnSprite1;
        }
        else
        {
            SoundBtn.GetComponent<Image>().sprite = btnSprite2;
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
