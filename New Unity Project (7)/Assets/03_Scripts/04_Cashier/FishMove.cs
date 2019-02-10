using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float randPowerStandard = 10.0f;
	private AudioSource audioSource;
	private const string bottomTag = "bottom";
	private bool isHitTheGround;
	public int beforeHitTheGround = 250;
	public int afterHitTheGround = 100;
	
	void Awake ()
	{
		audioSource = GetComponent<AudioSource>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	private void Start()
	{
		isHitTheGround = false;
		
		if (!CashierSfxManager.Instance.getIsSfxMute())
		{
			audioSource.Play();
		}
		
		float randPower = Random.Range(randPowerStandard - 3, randPowerStandard + 3);
		rb2d.AddForce(Vector3.up * randPower);
	}
	
	public virtual void OnCollisionEnter2D(Collision2D col)
	{	
		if (isHitTheGround)
		{
			if (!CashierSfxManager.Instance.getIsSfxMute())
			{
				audioSource.Play();
			}
			return;
		}
		
		if (col.gameObject.tag.Equals(bottomTag))
		{
			isHitTheGround = true;
			if (!CashierSfxManager.Instance.getIsSfxMute())
			{
				audioSource.Play();
			}
		}
	}

	private void OnMouseDown()
	{
		GameManager.Instance.setIsClear(true);
		if (!isHitTheGround) {GameManager.Instance.RespawnBonusEffect(this.transform);}
		addScore(beforeHitTheGround, afterHitTheGround);
		GameManager.Instance.playScannerSound();
		Destroy(gameObject, 0.01f);
	}
	
	private void addScore(int beforeHitTheGround, int afterHitTheGround)
	{
		int score = (isHitTheGround) ? afterHitTheGround : beforeHitTheGround;
		GameManager.Instance.changePriceText(score);
		GameManager.Instance.addScore(score);
	}
}
