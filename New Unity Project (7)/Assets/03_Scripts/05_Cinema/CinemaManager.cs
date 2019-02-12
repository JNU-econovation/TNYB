using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinemaManager : MonoBehaviour
{
    public AudioClip a, b;
    private float shakePower = 0.2f;
    public GameObject TicketL;
    public GameObject TicketC;
    public GameObject TicketR;
    public Sprite tearTicketL;
    public Sprite tearTicketC;
    public Sprite tearTicketR;
    public GameObject fakeTicketL; // 여기부터
    public GameObject fakeTicketC;
    public GameObject fakeTicketR;
    public Sprite faketearTicketL;
    public Sprite faketearTicketC;
    public Sprite faketearTicketR; // 여기까지
    public Transform TicketTfC;
    public Transform TicketTfL;
    public Transform TicketTfR;
    public GameObject SettingPanel;
    public GameObject pausePanel;

    private int Combo = 0;
    public Text scoreText;
    public Text finishScore;

    private GameObject clickedTicket;
    private Transform TicketTf;

    public static int cinema_score = 0;
    //public static int cinema_HighScore = 0;
    bool canRespawn = false;
    bool isMute = false;

    //Singleton
    public static CinemaManager instance;

    List<GameObject> TicketList = new List<GameObject>();
    List<Transform> TicketLocation = new List<Transform>(); //new
    private void Awake()
    {
        //TicketMove.throwPower += 10f;
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        pausePanel.SetActive(false);

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(Screen.width, (Screen.width * 16) / 9, true);

        TicketList.Add(TicketL);
        TicketList.Add(TicketC);
        TicketList.Add(TicketR);
        TicketList.Add(fakeTicketL); // Start
        TicketList.Add(fakeTicketC);
        TicketList.Add(fakeTicketR); // End
        TicketLocation.Add(TicketTfL);
        TicketLocation.Add(TicketTfC);
        TicketLocation.Add(TicketTfR);
    }

    void Start()
    {
        canRespawn = true;
        RespawnTicket();
    }

    public void RespawnTicket()
    {
        canRespawn = false;
        int randomTypeIndex1;
        if(Combo <= 10)
        {
             randomTypeIndex1 = UnityEngine.Random.Range(0, TicketList.Count-3);
           
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

    public void ButtonClickedL()
    {
       
        if (clickedTicket.tag == "TicketL")
        {
            
            clickedTicket.GetComponent<SpriteRenderer>().sprite = tearTicketL;
            // 이동 함수
            correct();
        }
        else if(clickedTicket.tag == "fakeTicketL")
        {
            clickedTicket.GetComponent<SpriteRenderer>().sprite = faketearTicketL;
            // 이동 함수
            correct();
        }
        else //if (clickedTicket.tag == "TicketC" || clickedTicket.tag == "TicketR")
        {
            WrongButton();

            speedReset();//
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
            
            clickedTicket.GetComponent<SpriteRenderer>().sprite = tearTicketL;
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
            //Destroy(clickedTicket, 1f);
            //clickedTicket.GetComponent<Rigidbody2D>().gravityScale = 10;
            speedReset();//
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
            clickedTicket.GetComponent<SpriteRenderer>().sprite = tearTicketL;
            correct();
        }
        else if (clickedTicket.tag == "fakeTicketR")
        {
            clickedTicket.GetComponent<SpriteRenderer>().sprite = faketearTicketR;
            // 이동 함수
            correct();
        }
        else //if (clickedTicket.tag == "TicketL" || clickedTicket.tag == "TicketC")
        {   
            WrongButton();
            //Destroy(clickedTicket, 1f);
            //clickedTicket.GetComponent<Rigidbody2D>().gravityScale = 10;
            speedReset();//
        }
        
        if (clickedTicket == null)
        {
            clickedTicket = null;
            canRespawn = true;

        }
    }
    private void soundEffect()
    {
        if (CinemaSfxManager.Instance.getIsSfxMute() != true)
        {
            CinemaSfxManager.Instance.GetComponent<AudioSource>().clip = CinemaSfxManager.Instance.correct;
            CinemaSfxManager.Instance.GetComponent<AudioSource>().Play();
        }
    }
    private void speedUp()//
    {
        TicketMove.throwPower += 5f;
    }
    private void speedReset()//
    {
        TicketMove.throwPower = 5f;
    }
    
    private void scoreUp()
    {
        if(Combo<10) cinema_score+=100;
        else if (Combo < 20) cinema_score += 200;
        else if (Combo < 30) cinema_score += 300;
        else if (Combo < 40) cinema_score += 400;
        else cinema_score += 500;
        scoreText.text = "" + cinema_score;
        finishScore.text = cinema_score.ToString();
    }

    public void WrongButton()
    {
        if (CinemaSfxManager.Instance.getIsSfxMute() != true)
        {
            CinemaSfxManager.Instance.GetComponent<AudioSource>().clip = CinemaSfxManager.Instance.wrong;
            CinemaSfxManager.Instance.GetComponent<AudioSource>().Play();
        }
        StartCoroutine(ShakeCoroutine(clickedTicket));
        if (cinema_score > 0)
        {
            cinema_score -= 100;
        }
        ComboReset();
        scoreText.text = "" + cinema_score;
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
    public void RollingScore()
    {
        StartCoroutine(IeResultScoreCountEffect());
    }
    public IEnumerator IeResultScoreCountEffect() //점수판돌아가는거
    {
        int tempScore = 0;
        CinemaSfxManager.Instance.playScoreCount();
        while (tempScore <= cinema_score)
        {
            tempScore += 1;
            tempScore += tempScore / 8;
            yield return null;
            finishScore.text = tempScore.ToString();
        }
        CinemaSfxManager.Instance.playCountOver();
        finishScore.text = cinema_score.ToString();
    }

    public void setCanRespawn(bool canRespawn)
    {
        this.canRespawn = canRespawn;
    }
    private void ComboUp()
    {
        Combo++;
    }
    private void ComboReset()
    {
        Combo = 0;
    }
    private void correct()
    {
        soundEffect();
        Destroy(clickedTicket, 0.2f);
        scoreUp();
        speedUp();//
        ComboUp();
        RespawnTicket();
    }
    public void OpenSetting()
    {
        SettingPanel.SetActive(true);
    }
    public void CloseSetting()
    {
        SettingPanel.SetActive(false);
    }

    public void SetScoreDB()
    {
        RealtimeDatabase.Instance.SetGameScore("score_cinema", cinema_score);
    }

    public void pauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
