using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
	private SpriteRenderer sr;
	public float speed = 3f;
	public static Hand instance;
	public Sprite HandSprite;

	private bool handFlag = true;
	
	public float delayTimeBetweenHands = 0.3f;
	
	// Audio
	public AudioClip throw1;
	public AudioClip throw2;
	public AudioClip throw3;
	private AudioSource audioSource;
	private List<AudioClip> audioClipList = new List<AudioClip>();

	private void Awake()
	{
		instance = this;
		sr = GetComponent<SpriteRenderer>();
		Color tColor = sr.color;
		tColor.a = 0f;
		sr.color = tColor;

		audioSource = GetComponent<AudioSource>();
		audioClipList.Add(throw1);
		audioClipList.Add(throw2);
		audioClipList.Add(throw3);
	}

	void Start () {
		Move();
	}
	
	private void Move()
	{
		StartCoroutine(IeMoveDownCoroutine());
		StartCoroutine(IeAlphaUpCoroutine());
	}
	
	private void Update()
	{
		if (transform.position.y < 0.14f && handFlag)
		{
			sr.sprite = HandSprite;
			
			//Respawn Marchandise
			GameManager.Instance.setbCanMarchandiseRespawn(true);
			playThrowSound();

			StartCoroutine(IeMoveUpCoroutine());
			StartCoroutine(IeAlphaDownCoroutine());
			DestroyHand(2f);
			
			StartCoroutine(IeRespawnHandIn(delayTimeBetweenHands));
	
			handFlag = false;
		}
	}

	private void playThrowSound()
	{
		if (!CashierSfxManager.Instance.getIsMute())
		{
			int randIndex = Random.Range(0, audioClipList.Count);
			audioSource.clip = audioClipList[randIndex];
			audioSource.Play();	
		}
	}

	private IEnumerator IeMoveDownCoroutine()
	{
		for(int i =0;i<30;i++)
		{
			yield return new WaitForSeconds(0.01f);
			transform.Translate(Vector3.up * Time.deltaTime * speed);	
		}
	}
	
	private IEnumerator IeMoveUpCoroutine()
	{
		yield return null;
		for(int i =0;i<20;i++)
		{
			yield return new WaitForSeconds(0.01f);
			transform.Translate(Vector3.down * Time.deltaTime * speed);	
		}
	}
	
	private IEnumerator IeAlphaUpCoroutine()
	{
		float t = 0;
		
		while (t < 0.95)
		{
			Color tColor = sr.color;
			t += 0.07f;
			tColor.a = t;
			sr.color = tColor;
			yield return null;
		}
	}

	private IEnumerator IeStartAlphaDown(float handAlphaDownDelay)
	{
		yield return new WaitForSeconds(handAlphaDownDelay);
		StartCoroutine(IeAlphaDownCoroutine());
	}
	
	private IEnumerator IeAlphaDownCoroutine()
	{
		float t = 0.95f;
		
		while (t > 0)
		{
			Color tColor = sr.color;
			t -= 0.03f;
			tColor.a = t;
			sr.color = tColor;
			yield return null;
		}
	}
	
	public IEnumerator IeRespawnHandIn()
	{
		yield return new WaitForSeconds(2.0f);
		GameManager.Instance.setbCanHandRespawn(true);
	}

	public IEnumerator IeRespawnHandIn(float time)
	{
		yield return new WaitForSeconds(time);
		GameManager.Instance.setbCanHandRespawn(true);
	}
	
	public void DestroyHand(float destroyDelay)
	{
		Destroy(gameObject, destroyDelay);
	}
}
