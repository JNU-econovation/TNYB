using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour {

	public PhysicsMaterial2D pm2d;
	private Rigidbody2D rb2d;
	public float randPowerStandard = 10.0f;
	private AudioSource audioSource;
	private const string bottomTag = "bottom";
	private bool isHitTheGround = false;
	public int beforeHitTheGround = 250;
	public int afterHitTheGround = 100;
	
	// Use this for initialization
	void Awake ()
	{
		pm2d.bounciness = Random.Range(0.9f, 1.0f);
		audioSource = GetComponent<AudioSource>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	private void Start()
	{
		audioSource.Play();
		float randPower = Random.Range(randPowerStandard - 3, randPowerStandard + 3);
		rb2d.AddForce(Vector3.up * randPower);
	}
	
	public virtual void OnCollisionEnter2D(Collision2D col)
	{	
		if (isHitTheGround)
		{
			audioSource.Play();
			return;
		}
		
		if (col.gameObject.tag.Equals(bottomTag))
		{
			isHitTheGround = true;
			audioSource.Play();
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

	public void Click()
	{
		// 
		// 점수 +
	}
}
