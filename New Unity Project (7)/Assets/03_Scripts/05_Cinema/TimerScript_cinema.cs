using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript_cinema : MonoBehaviour {
   Image timerBar;
    public GameObject finishPanel;
    public float maxTime = 60f;
    public static float timeLeft;     // public GameObject timesUpText;
    private int count = 0; //DB 용

    void Start () {
        //  timesUpText.SetActive(false);
        count = 0;
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        finishPanel.SetActive(false);
    }
	void FixedUpdate () {
        if(timeLeft < 0)
        {
            finishPanel.SetActive(true);
            /*if (CinemaManager.cinema_score > CinemaManager.cinema_HighScore)
            {
                CinemaManager.cinema_HighScore = CinemaManager.cinema_score;
                PlayerPrefs.SetInt("Cinema_MaxSc", CinemaManager.cinema_HighScore);
            }*/
        }
        if (timeLeft > 0)
        {
            //if()
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }
        else {          // timesUpText.SetActive(true);
            Time.timeScale = 0;
            if (count == 0)
            {
                count++;
                CinemaManager.instance.SetScoreDB();
            }
        }
	}
}
