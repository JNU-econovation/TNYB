using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript_cinema : MonoBehaviour {
   Image timerBar;
    public GameObject finishPanel;
    public float maxTime = 60f;
    public static float timeLeft;     // public GameObject timesUpText;
    private bool dbOnce = true; //DB 용

    void Start () {
        //  timesUpText.SetActive(false);
        dbOnce = true;
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        finishPanel.SetActive(false);
    }
	void FixedUpdate () {
        if(timeLeft <= 0)
        {
            finishPanel.SetActive(true);
            CinemaManager.instance.RollingScore();
            if (dbOnce)
            {
                dbOnce = false;
                CinemaManager.instance.SetScoreDB();

                //CinemaManager.instance.StartCoroutine(CinemaManager.instance.IeResultScoreCountEffect());
            }
        }
        if (timeLeft > 0)
        {
            //if()
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }
	}
}
