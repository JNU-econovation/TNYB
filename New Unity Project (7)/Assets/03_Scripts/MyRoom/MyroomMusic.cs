using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyroomMusic : MonoBehaviour
{
    public AudioClip myroomMusics;
    public bool isMfxMute;

    private static MyroomMusic instance;

    public static MyroomMusic Instance
    {
        get { return instance; }
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
            GetComponent<AudioSource>().clip = myroomMusics;
            GetComponent<AudioSource>().Play();

        }
    }
}
