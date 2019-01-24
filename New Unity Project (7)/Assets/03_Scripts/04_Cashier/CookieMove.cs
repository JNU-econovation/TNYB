using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieMove : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField]private float forceUpPower = 50.0f;
	
    private bool isHitTheGround = false;
    private const string bottomTag = "bottom";
    
    public int beforeHitTheGround = 3500;
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
	
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
    void Start ()
    {
        float randomForceUpPower = Random.Range(forceUpPower - 50, forceUpPower + 50);
        rb2d.AddForce(Vector3.up * randomForceUpPower);
    }
}
