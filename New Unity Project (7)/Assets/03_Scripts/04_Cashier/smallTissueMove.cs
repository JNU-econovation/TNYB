using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallTissueMove : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float randPowerStandard = 10.0f;
    
    public int beforeHitTheGround = 500;
    public int afterHitTheGround = 300;
    
    private bool isHitTheGround;
    private const string bottomTag = "bottom";
    
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

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
        float randPower = Random.Range(randPowerStandard - 3, randPowerStandard + 3);
        rb2d.AddForce(Vector3.up * randPower);
    }

    private void OnMouseDown()
    {
        GameManager.Instance.clickTissue();
        if (!isHitTheGround) {GameManager.Instance.RespawnBonusEffect(this.transform);}
        addScore(beforeHitTheGround, afterHitTheGround);
        if (GameManager.Instance.getNumberOfTissue() == 0)
        {
            GameManager.Instance.setIsClear(true);
        }
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
