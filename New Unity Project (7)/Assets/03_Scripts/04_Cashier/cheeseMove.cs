using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class cheeseMove : MonoBehaviour
{
	private Rigidbody2D rb2d;
	public float randPowerStandard = 10.0f;
	[SerializeField]private float forceHorizontalPower = 2.0f;
	[SerializeField]private float torquePower = 300.0f;
	private int leftRight;
	private bool isHitTheGround = false;
	private const string bottomTag = "bottom";
	
	public AudioClip boing1;
	public AudioClip boing2;
	private AudioSource audioSource;
	private List<AudioClip> audioClipList = new List<AudioClip>();
	
	public int beforeHitTheGround = 2000;
	public int afterHitTheGround = 1000;
	
	// Use this for initialization
	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
		
		audioSource = GetComponent<AudioSource>();
		audioClipList.Add(boing1);
		audioClipList.Add(boing2);
	}

	private void Start()
	{
		float randPower = Random.Range(randPowerStandard - 3, randPowerStandard + 3);
		rb2d.AddForce(Vector3.up * randPower);
	}

	public virtual void OnCollisionEnter2D(Collision2D col)
	{		
		if (isHitTheGround)
		{
			playBoingSound();
			return;
		}
		
		if (col.gameObject.tag.Equals(bottomTag))
		{
			playBoingSound();
			isHitTheGround = true;
			leftRight = Random.Range(0, 2);
			float randomForceHorizontalPower = Random.Range(forceHorizontalPower - 30, forceHorizontalPower + 30);
		
			if (leftRight == 0)
			{
				rb2d.AddForce(Vector3.left * randomForceHorizontalPower);
				rb2d.AddTorque(torquePower);
			}
			else
			{
				rb2d.AddForce(Vector3.right * randomForceHorizontalPower);
				rb2d.AddTorque(-torquePower);
			}
		}
	}
	
	private void OnMouseDown()
	{
		GameManager.Instance.setIsClear(true);
		if (!isHitTheGround) {GameManager.Instance.RespawnBonusEffect(this.transform);}
		addSore(beforeHitTheGround, afterHitTheGround);
		GameManager.Instance.playScannerSound();
		Destroy(gameObject, 0.01f);
	}

	private void addSore(int beforeHitTheGround, int afterHitTheGround)
	{
		int score = (isHitTheGround) ? afterHitTheGround : beforeHitTheGround;
		GameManager.Instance.changePriceText(score);
		GameManager.Instance.addScore(score);
	}
	
	private void playBoingSound()
	{
		if (!CashierSfxManager.Instance.getIsSfxMute())
		{
			int randIndex = Random.Range(0, audioClipList.Count);
            		audioSource.clip = audioClipList[randIndex];
            		audioSource.Play();
		}
	}
}
