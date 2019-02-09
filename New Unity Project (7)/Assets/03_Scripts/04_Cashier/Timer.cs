using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    
	private Image timeBar;
	public float maxTime = 10f;
	public float warnTime = 15f;
	private float timeLeft;
    public GameObject finishPanel;
	private bool isResultShowed;
	public string timeBarColor_norm = "FFBB06";
	public string timeBarColor_10 = "FF3A06";

	private void Awake()
	{
		timeBar = GetComponent<Image>();
		timeBar.color = GetColorFromString(timeBarColor_norm);
	}

	void Start () {
		timeLeft = maxTime;
        finishPanel.SetActive(false);
		isResultShowed = false;
	}
	
	void Update () {
		
		if (timeLeft < 0)
		{
			CashierMusicManager.Instance.stopMusic();
			finishPanel.SetActive(true);
			if (!isResultShowed)
			{
				isResultShowed = true;
				StartCoroutine(GameManager.Instance.IeResultScoreCountEffect());
			}
		}

		if (timeLeft < warnTime)
		{
			timeBar.color = GetColorFromString(timeBarColor_10);
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

	private int HexToDec(string hex)
	{
		int dec = System.Convert.ToInt32(hex, 16);
		return dec;
	}

	private float HexToFloatNormalized(string hex)
	{
		return HexToDec(hex) / 255f;
	}

	private Color GetColorFromString(string HexString)
	{
		float red = HexToFloatNormalized(HexString.Substring(0, 2));
		float green = HexToFloatNormalized(HexString.Substring(2, 2));
		float blue = HexToFloatNormalized(HexString.Substring(4, 2));
		return new Color(red, green, blue);
	}
}
