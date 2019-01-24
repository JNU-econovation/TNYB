using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuthManager : MonoBehaviour
{
    public InputField nicknameInput;
    public Image checkImage;
    
    private void Awake()
    {
        checkImage.enabled = false;
        
        // 해상도
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(Screen.width, (Screen.width * 16)/9, true);
    }

    public void PopupCheck()
    {
        checkImage.enabled = true;
        nicknameInput.DeactivateInputField();
        GetComponent<AudioSource>().Play();
    }
    public void ClickStart()
    {
        GetComponent<AudioSource>().Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
