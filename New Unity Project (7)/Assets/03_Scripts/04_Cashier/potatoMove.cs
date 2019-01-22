using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potatoMove : MonoBehaviour {

	private Rigidbody2D rb2d;
	[SerializeField]private float forceHorizontalPower = 2.0f;
	[SerializeField]private float forceUpPower = 2.0f;
	[SerializeField]private float torquePower = 500.0f;
	private int leftRight;
	
	private bool isHitTheGround = false;
	private const string bottomTag = "bottom";
    
	public int beforeHitTheGround = 2500;
	public int afterHitTheGround = 1000;
	
	public virtual void OnCollisionEnter2D(Collision2D col)
	{		
		if (isHitTheGround)
		{
			return;
		}
		
		if (col.gameObject.tag.Equals(bottomTag))
		{
			// Hit The Ground
			isHitTheGround = true;
		}
	}
	
	private void OnMouseDown()
	{
		GameManager.Instance.setIsClear(true);
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

	private void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Start ()
	{
		// Random Setting
		leftRight = Random.Range(0, 2);
		float randomForceHorizontalPower = Random.Range(forceHorizontalPower - 50, forceHorizontalPower + 50);
		float randomForceUpPower = Random.Range(forceUpPower - 50, forceUpPower + 50);
		
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
		
		rb2d.AddForce(Vector3.up * randomForceUpPower);
	}
}
