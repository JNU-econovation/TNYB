using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketMove : MonoBehaviour {
    public static float throwPower =5f;
    //public static float throwPower2 = 0f;
    private Rigidbody2D rb2d;
    //private Rigidbody2D rb2d2;


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
       // rb2d2 = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        Throw ();
    }

    public virtual void Throw()
    {
        rb2d.AddForce(Vector3.up * throwPower);
      //  rb2d2.AddForce(Vector3.down * throwPower2);
    }

    /*
	void Start () {
        StartCoroutine(IeTicketMove());
	}

    IEnumerator IeTicketMove()
    {
         
        for(int i = 0; i<10; i++)
        {
            transform.Translate(Vector3.left * 0.7f);
            yield return null;
        }
    }*/
}
