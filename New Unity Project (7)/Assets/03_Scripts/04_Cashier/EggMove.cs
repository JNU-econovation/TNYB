using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMove : MonoBehaviour {

	private Rigidbody2D rb2d;
	private SpriteRenderer sr;
	public Sprite CrushedEgg;
	public float randPowerStandard = 10.0f;
	
	private AudioSource audioSource;
	
	private bool isHitTheGround;
	private const string bottomTag = "bottom";
    
	public int beforeHitTheGround = 150;
	
	private void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
		rb2d = GetComponent<Rigidbody2D>();
		
		float randPower = Random.Range(randPowerStandard - 3, randPowerStandard + 3);
		rb2d.AddForce(Vector3.up * randPower);
		isHitTheGround = false;
		
		audioSource = GetComponent<AudioSource>();
	}
	
	private void OnMouseDown()
	{
		if(!isHitTheGround)
		{
			GameManager.Instance.setIsClear(true);
			addScore(beforeHitTheGround);
			GameManager.Instance.playScannerSound();
			Destroy(gameObject, 0.01f);
		}
	}
	
	public virtual void OnCollisionEnter2D(Collision2D col)
	{
		if (isHitTheGround)
		{
			return;
		}
		
		if (col.gameObject.tag.Equals(bottomTag))
		{
			isHitTheGround = true;
			sr.sprite = CrushedEgg;

			audioSource.Play();
			
			// 얼마 뒤에 제거
			StartCoroutine(IeAlphaDownCoroutine());
			StartCoroutine(IeDestroyCrushedEggAfterWaiting());
		}
	}

	public IEnumerator IeDestroyCrushedEggAfterWaiting()
	{
		yield return new WaitForSeconds(1.5f);
		GameManager.Instance.setIsClear(true);
		Destroy(gameObject, 0.1f);
	}
	
	public IEnumerator IeAlphaDownCoroutine()
	{
		float t = 0.95f;
		
		while (t > 0)
		{
			Color tColor = sr.color;
			t -= 0.02f;
			tColor.a = t;
			sr.color = tColor;
			yield return null;
		}
	}
	
	private void addScore(int beforeHitTheGround)
	{
		GameManager.Instance.changePriceText(beforeHitTheGround);
		GameManager.Instance.addScore(beforeHitTheGround);
	}
}