using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinema_Tutorial : MonoBehaviour
{
    public AudioClip a, b;
    private float shakePower = 0.2f;
    public GameObject TicketR;
    public Sprite tearTicketR;
    public GameObject fakeTicketC;
    public Sprite faketearTicketC;
    public Transform TicketTfC;

    private GameObject clickedTicket;
    private Transform TicketTf;

    bool canRespawn = false;

    public static Cinema_Tutorial instance;

    private void Awake()
    {
        //TicketMove.throwPower += 10f;
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(Screen.width, (Screen.width * 16) / 9, true);

    }
    /*
    void Start()
    {
        canRespawn = true;
        RespawnTicket();
    }
    
      
     
    public void RespawnTicket()
    {
        canRespawn = false;
        int randomTypeIndex1;
        if (Combo <= 10)
        {
            randomTypeIndex1 = UnityEngine.Random.Range(0, TicketList.Count - 3);

        }
        else
        {
            randomTypeIndex1 = UnityEngine.Random.Range(0, TicketList.Count);

        }
        int randomTypeIndex2 = UnityEngine.Random.Range(0, TicketLocation.Count);
        clickedTicket = Instantiate(TicketList[randomTypeIndex1]);
        TicketTf = TicketLocation[randomTypeIndex2];
        clickedTicket.transform.position = TicketTf.position;
    }
    // Update is called once per frame
    public void ButtonClickedL()
    {

        if (clickedTicket.tag == "TicketL")
        {

            clickedTicket.GetComponent<SpriteRenderer>().sprite = tearTicketL;
            // 이동 함수
            correct();
        }
        else if (clickedTicket.tag == "fakeTicketL")
        {
            clickedTicket.GetComponent<SpriteRenderer>().sprite = faketearTicketL;
            // 이동 함수
            correct();
        }
        else //if (clickedTicket.tag == "TicketC" || clickedTicket.tag == "TicketR")
        {
            WrongButton();

        
        }
        if (clickedTicket == null)
        {
            clickedTicket = null;
            canRespawn = true;

        }
    }

    public void ButtonClickedC()
    {
        if (clickedTicket.tag == "TicketC")
        {

          ////  clickedTicket.GetComponent<SpriteRenderer>().sprite = tearTicketL;
            correct();
        }
        else if (clickedTicket.tag == "fakeTicketC")
        {
            clickedTicket.GetComponent<SpriteRenderer>().sprite = faketearTicketC;
            // 이동 함수
            correct();
        }
        else //if (clickedTicket.tag == "TicketL" || clickedTicket.tag == "TicketR")
        {
            WrongButton();
    
        }
        if (clickedTicket == null)
        {
            clickedTicket = null;
            canRespawn = true;

        }
    }

    public void ButtonClickedR()
    {
        if (clickedTicket.tag == "TicketR")
        {
          ////  clickedTicket.GetComponent<SpriteRenderer>().sprite = tearTicketL;
            correct();
        }
        else if (clickedTicket.tag == "fakeTicketR")
        {
          /////  clickedTicket.GetComponent<SpriteRenderer>().sprite = faketearTicketR;
            // 이동 함수
            correct();
        }
        else //if (clickedTicket.tag == "TicketL" || clickedTicket.tag == "TicketC")
        {
            WrongButton();
            //Destroy(clickedTicket, 1f);
            //clickedTicket.GetComponent<Rigidbody2D>().gravityScale = 10;
        }

        if (clickedTicket == null)
        {
            clickedTicket = null;
            canRespawn = true;

        }
    }
    private void soundEffect()
    {
        GetComponent<AudioSource>().clip = b;
    }


    public void WrongButton()
    {
        GetComponent<AudioSource>().clip = a;
        GetComponent<AudioSource>().Play();
        StartCoroutine(ShakeCoroutine(clickedTicket));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ShakeCoroutine(GameObject obj) //틀렸을 때 오브젝트 흔들림.
    {
        float t = 1f;
        Vector3 originV = obj.transform.position;
        while (t > 0f)
        {
            t -= 0.1f;
            obj.transform.position = originV + (Vector3)UnityEngine.Random.insideUnitCircle * shakePower * t;
            yield return null;
        }
        obj.transform.position = originV;
    }

    public bool getCanRespawn()
    {
        return this.canRespawn;
    }

    public void setCanRespawn(bool canRespawn)
    {
        this.canRespawn = canRespawn;
    }
   
    private void correct()
    {
        soundEffect();
        Destroy(clickedTicket, 0.2f);
   
        RespawnTicket();
    }
    */
}
