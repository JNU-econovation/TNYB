using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myroomSFX : MonoBehaviour
{
    public AudioClip myroomMusic;
    public bool isMfxMute;

    private static myroomSFX instance;

    public static myroomSFX Instance
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
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("isMfxMute", 0) == 1)
        {
            isMfxMute = true;
        }
        else
        {
            isMfxMute = false;
           
        }
        setMyRoomMusic();

    }

    public void setMyRoomMusic()
    {
        if (isMfxMute)
            GetComponent<AudioSource>().Stop();
        else
        {
            GetComponent<AudioSource>().clip = myroomMusic;
            GetComponent<AudioSource>().Play();

        }
    }
}
