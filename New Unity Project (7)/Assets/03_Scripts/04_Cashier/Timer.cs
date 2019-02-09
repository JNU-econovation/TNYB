using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    
	private Image timeBar;
	public float maxTime = 10f;
	private float timeLeft;
    public GameObject finishPanel;

	// Use this for initialization
	void Start () {
		timeBar = GetComponent<Image>();
		timeLeft = maxTime;
        finishPanel.SetActive(false);
	}
	
	void Update () {
		if (timeLeft < 0)
		{
			finishPanel.SetActive(true);
			// textEffect
			GameManager.Instance.IeResultScoreEffect();
		}
        if (timeLeft > 0)
		{
			timeLeft -= Time.deltaTime;
			timeBar.fillAmount = timeLeft / maxTime;
		}
		else
		{
			Time.timeScale = 0;
		}
	}
}
