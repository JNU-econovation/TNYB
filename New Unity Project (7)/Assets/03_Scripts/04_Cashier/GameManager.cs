using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //from 튜토리얼관련
    public GameObject tutoBtn;
    public GameObject tutoCloseBtn;
    public GameObject tutoNextBtn;
    public GameObject tutoPrevBtn;
    public GameObject tutoPanel;
    public GameObject tuto1;
    public GameObject tuto2;
    //to 
    public GameObject pausePanel;
	public GameObject hand;
	public Transform handTf1, handTf2, handTf3;
	private List<Transform> handTfList = new List<Transform>();
	public static int handTfIndex;
	
	public Transform marchandiseTf1, marchandiseTf2, marchandiseTf3;
	private List<Transform> marchandiseTfList = new List<Transform>();
	
	List<GameObject> marchandisePrefabsList = new List<GameObject>();
	public GameObject marchandise1, marchandise2, marchandise3, marchandise4, marchandise5, marchandise6, marchandise7, marchandise8;

	public GameObject bonusEffect;
	
	// Text
	public Text PriceTag;
	public Text ScoreText;
    public Text resultScore;

	
	// Score
	private int score;
	
	// Sound
	private AudioSource audioSource;
	public AudioClip scanner;
	
	// Tissue Zone
	private int numberOfTissue;

	private bool bCanHandRespawn;
	private bool bCanMarchandiseRespawn;
	private bool isClear;

	private static GameManager instance;

	public static GameManager Instance
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

		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Screen.SetResolution(Screen.width, (Screen.width * 16)/9, true);

        handTfList.Add(handTf1);
		handTfList.Add(handTf2);
		handTfList.Add(handTf3);
		
		// marchandise List Set
		
		marchandiseTfList.Add(marchandiseTf1);
		marchandiseTfList.Add(marchandiseTf2);
		marchandiseTfList.Add(marchandiseTf3);
		
		marchandisePrefabsList.Add(marchandise1);
		marchandisePrefabsList.Add(marchandise2);
		marchandisePrefabsList.Add(marchandise3);
		marchandisePrefabsList.Add(marchandise4);
		marchandisePrefabsList.Add(marchandise5);
		marchandisePrefabsList.Add(marchandise6);
		marchandisePrefabsList.Add(marchandise7);
		marchandisePrefabsList.Add(marchandise8);	// Egg
		
		// Audio
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = scanner;
	}
	
	void Start ()
	{
		score = 0;
		Time.timeScale = 1;
        pausePanel.SetActive(false);
        bCanHandRespawn = true;
		isClear = true;
	}

    public void pauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    private void FixedUpdate()
	{
		if (bCanHandRespawn && isClear)
		{
			RespawnRandomTfHand();
		}
		
		if (bCanMarchandiseRespawn)
		{
			RespawnMarchandise();
			bCanMarchandiseRespawn = false;
		}

		ScoreText.text = score.ToString();
//        resultScore.text = ScoreText.text;
	}

	private void RespawnRandomTfHand()
	{
		bCanHandRespawn = false;
		handTfIndex = Random.Range(0, handTfList.Count);
		GameObject tempHand;
		tempHand = Instantiate(hand);
		tempHand.transform.position = handTfList[handTfIndex].position;
	}

	public void RespawnMarchandise()
	{
		isClear = false;

		int marchandiseIndex = Random.Range(0, marchandisePrefabsList.Count);
		
		GameObject tempMarchandise;
		tempMarchandise = Instantiate(marchandisePrefabsList[marchandiseIndex]);
		tempMarchandise.transform.position = marchandiseTfList[handTfIndex].position;
	}

	public void RespawnBonusEffect(Transform clickTransform)
	{
		GameObject tempHeart;
		tempHeart = Instantiate(bonusEffect);
		tempHeart.transform.position = clickTransform.transform.position;
	}
	
	// Price Text
	public void changePriceText(int price)
	{
		PriceTag.text = price.ToString() + "$";
	}
	
	public IEnumerator IeResultScoreCountEffect()
	{
		int tempScore = 0;
		// count sfx
		CashierSfxManager.Instance.playScoreCount();
		
		while (tempScore <= score)
		{
			tempScore += 1;
			tempScore += tempScore/8;
			yield return null;
			resultScore.text = tempScore.ToString();
		}
		// count done sfx
		CashierSfxManager.Instance.playCountOver();
		resultScore.text = score.ToString();
	}

	public void addScore(int score)
	{
		this.score += score;
	}
	
	// Play Audio
	public void playScannerSound()
	{
		if (!CashierSfxManager.Instance.getIsSfxMute())
		{
			audioSource.Play();	
		}
	}

	public void updateRankScore()
	{
		RealtimeDatabase.Instance.SetGameScore("score_cashier", score);
	}

	public void setbCanHandRespawn(bool b)
	{
		bCanHandRespawn = b;
	}
	
	public void setbCanMarchandiseRespawn(bool b)
	{
		bCanMarchandiseRespawn = b;
	}

	public void setIsClear(bool b)
	{
		isClear = b;
	}

	public void generateTissue()
	{
		numberOfTissue = 4;
	}
	
	public void clickTissue()
	{
		numberOfTissue--;
	}

	public int getNumberOfTissue()
	{
		return numberOfTissue;
	}
    //from 튜토리얼 관련 스크립트
    public void OpenTuto()
    {
        tutoPanel.SetActive(true);
    }
    public void CloseTuto()
    {
        tutoPanel.SetActive(false);
    }
    public void NextTutoBtn()
    {
        tutoNextBtn.SetActive(false);
        tutoPrevBtn.SetActive(true);
        tuto1.SetActive(false);
        tuto2.SetActive(true);
    }
    public void PrevTutoBtn()
    {
        tutoNextBtn.SetActive(true);
        tutoPrevBtn.SetActive(false);
        tuto2.SetActive(false);
        tuto1.SetActive(true);
    }
    //to
}
