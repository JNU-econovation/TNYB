using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnScript : MonoBehaviour
{

    public Sprite btnSprite1;
    public Sprite btnSprite2;
    // Start is called before the first frame update
    void Start()
    {
        ClickEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickEvent()
    {
        if (factorySfxManager.Instance.getisSfxMute())
            GetComponent<Image>().sprite = btnSprite1;
        else
            GetComponent<Image>().sprite = btnSprite2;
    }
    public void BtnClickEvent_Music()
    {
        if (FactoryManager.Instance.getMusic_bool())
        {
            GetComponent<Image>().sprite = btnSprite1;
        }
        else
        GetComponent<Image>().sprite = btnSprite2;
    }
    public void ClickEvent_Mart()
    {
        if (CashierSfxManager.Instance.getIsSfxMute())
        {
            GetComponent<Image>().sprite = btnSprite1;
        }
        else
        {
            GetComponent<Image>().sprite = btnSprite2;
        }
    }
    public void BtnClickEvent_Music_Mart()
    {
        if (CashierMusicManager.Instance.getIsMusicMute())
        {
            GetComponent<Image>().sprite = btnSprite1;
        }
        else
        {
            GetComponent<Image>().sprite = btnSprite2;
        }
    }
}

