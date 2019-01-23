using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript_cinema : MonoBehaviour {
   Image timerBar;
    public GameObject finishPanel;
    public float maxTime = 60f;
    public static float timeLeft;     // public GameObject timesUpText;

    void Start () {     //  timesUpText.SetActive(false);
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        finishPanel.SetActive(false);
    }
	void FixedUpdate () {
        if(timeLeft < 0)
        {
            finishPanel.SetActive(true);
        }
        if (timeLeft > 0)
        {   
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }
        else {          // timesUpText.SetActive(true);
            Time.timeScale = 0;
        }
	}
}
