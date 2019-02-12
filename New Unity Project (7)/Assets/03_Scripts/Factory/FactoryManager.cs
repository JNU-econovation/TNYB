using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryManager : MonoBehaviour {


    public Text recycleText;
    public Sprite transparent;
    public Image changeImage1, changeImage2;
    public static FactoryManager Instance;
    private bool isPaused = false;
    public Image selector;
    public Button[] btn = new Button[8];
    private string[] kind = {"pet", "pet", "pet", "paper",
        "paper", "paper", "bottle", "bottle", "bottle",
        "can","can","can","pet","paper", "bottle", "can"};
    private float moveSpeed=1;

    public Image[] rightArrow = new Image[2];
    public Image[] objImage = new Image[8]; //세팅된 이미지
    public Text scoreText, resultText;
    private int score = 0;
    private int clickCount;
    int beforeA, beforeB, afterA, afterB;

    public Image[] image = new Image[4];
    public Sprite[] pet = new Sprite[4];
    public Sprite[] bottle = new Sprite[4];
    public Sprite[] paper = new Sprite[4];
    public Sprite[] can = new Sprite[4];

    public Sprite[] trashImage = new Sprite[16];
    private string[] recycleName = { "pet", "paper", "can", "bottle" };
    private string select;
    private int count;

    private float speed =4.0f;
    public float shakePower = 1f;
    private int[] num = new int[8];
    private float left, right = 0;

    private bool music_bool;
    private bool sound_bool;
    public GameObject Music;




   
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    private bool combo = false;

    public Text remainCount;
    float timer;
    float waitingTime;
    bool a = false;

    public string getSelect()
    {
        return select;
    }
    void Awake()
    {
        if (!Instance)
            Instance = this;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(Screen.width, (Screen.width * 16)/9, true);
    }
    // Use this for initialization
    void Start() {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        score = 0;

        FirstMusicSetting();
        //StartCoroutine(Changing(speed));
        makeTrash_1();
      
        timer = 0.0f;
        waitingTime = 0.7f;
    }
    


    void Update()
    {
       //changeImage1.GetComponent<Image>().sprite = trashImage[num[afterA]];
       //changeImage2.GetComponent<Image>().sprite = trashImage[num[afterB]];

        timer += Time.deltaTime;
        if (a)
        {
            //Color color = new Color(255, 255, 255, 0.1f+timer);
            //objImage[afterA].color = color;
            //objImage[afterB].color = color;
            Color redColor = new Color(255, 0, 0, 0.1f + timer);
            rightArrow[0].color = redColor;
            rightArrow[1].color = redColor;

        }
        else
        {
           //Color color = new Color(255, 255, 255, 0.8f-timer);
            //objImage[afterA].color = color;
           //objImage[afterB].color = color;
            Color redColor = new Color(255, 0, 0, 0.8f - timer);
            rightArrow[0].color = redColor;
            rightArrow[1].color = redColor;
        }
        

        if (timer > waitingTime)
        {
            if (a)
                a = false;
            else
                a = true;
            
            if (combo)
            {
                if (a)
                {
                    a = false;
                }
                else
                {
                    a = true;
                }
            }
            timer = 0;
        }
        if (!isPaused)
        {
            left += moveSpeed;
            right += moveSpeed;
            if (left > 700)
            {
                left = right = 0;
            }
            selector.GetComponent<RectTransform>().offsetMin = new Vector2(left, 0);//left-bottom
            selector.GetComponent<RectTransform>().offsetMax = new Vector2(right, 0);//right-top
        }
        
    }

    void UpScore() //점수 업
    {
        if (combo)
        {
            score += 200;
            moveSpeed += 0.2f;
        }
        else
        {
            score += 100;
            moveSpeed = 1f;
        }

        scoreText.text =  score.ToString();
        resultText.text = "Score\n" + score.ToString();
        
    }

    void DownScore() //점수 다운
    {
        combo = false;
        if(score > 10)
        {
            score -= 50;
            scoreText.text = score.ToString();
            resultText.text = "Score\n" + score.ToString();
        }
        else
        {
            scoreText.text = "0";
            resultText.text = "Score\n" + score.ToString();
        }
        speed = 4.0f;
        
    }
   void setSelector() //위에 pet, can, bottle, paper 선택창 세팅
    {
        recycleText.text = select;
        left = right = 0;
        if(select == recycleName[0])
        {
            for (int i = 0; i < 4; i++)
            {
                image[i].GetComponent<Image>().sprite = pet[i];
            }
        }
        else if (select == recycleName[3])
        {
            for (int i = 0; i < 4; i++)
            {
                image[i].GetComponent<Image>().sprite = bottle[i];
            }
        }else if(select == recycleName[2])
        {
            for (int i = 0; i < 4; i++)
            {
                image[i].GetComponent<Image>().sprite = can[i];
            }
        }else if(select == recycleName[1])
        {
            for (int i = 0; i < 4; i++)
            {
                image[i].GetComponent<Image>().sprite = paper[i];
            }
        }
    }
    void set() //8개 재화용품 세팅
    {
        count = 0;
        for(int i=0; i<8; i++)
        {
            int random = Random.Range(0, 16);
            if (select == kind[random])
                count++;
            clickCount = count;
            objImage[i].GetComponent<Image>().sprite = trashImage[random];
            num[i] = random;
           
        }
        if (count == 0)
        {
            int ran = Random.Range(0, 8);
            int tmpran;
            while (true)
            {
                tmpran = Random.Range(0, 16);
                if (kind[tmpran] == select) break;
            }
            num[ran] = tmpran;
            objImage[ran].GetComponent<Image>().sprite = trashImage[tmpran];
            count++;
        }
        remainCount.text = "남은 개수 : " + count.ToString();
    }  
    public void ItemDestroy(int i)
    {
        if(objImage[i].GetComponent<Image>().sprite != transparent)
        {
            clickCount -= 1;
            if ( kind[num[i]] == select)
            {

                if(sound_bool)
                    GetComponent<AudioSource>().Play();
                objImage[i].GetComponent<Image>().sprite =transparent;
                count--;
                if(count == 0)
                {
                    UpScore();
                    if (clickCount == 0)
                    {
                        speed -= 0.2f;
                        combo = true;
                    }
                    makeTrash_1();
                }
            }
            else
            {
                Shake(objImage[i]);
                DownScore();
            }
        }

        remainCount.text = "남은 개수 : " + count.ToString();

    }

    void Shake(Image obj)
    {
        StartCoroutine(ShakeCoroutine(obj));
    }
    void makeTrash_1()
    {
        select = recycleName[Random.Range(0, 4)];

        set();
        setSelector();
    }
    void changeTrash()
    {

        Color color = new Vector4(255, 255, 255, 1);
        objImage[afterA].color = color;
        objImage[afterB].color = color;
        beforeA = afterA;
        beforeB = afterB;

        btn[beforeA].GetComponent<Button>().interactable = false; //바뀌는 도중 클릭 하지 않도록 비활성화
        btn[beforeB].GetComponent<Button>().interactable = false;

       
        objImage[beforeA].GetComponent<Image>().sprite = trashImage[num[beforeB]];
        objImage[beforeB].GetComponent<Image>().sprite = trashImage[num[beforeA]];

        int tmpnum = num[beforeB];
        num[beforeB] = num[beforeA];
        num[beforeA] = tmpnum;
        

        btn[beforeA].GetComponent<Button>().interactable = true;
        btn[beforeB].GetComponent<Button>().interactable = true;
        afterA = Random.Range(0, 8);
        afterB = Random.Range(0, 8);
        while (afterA == afterB)
            afterB = Random.Range(0, 8);



    }

    public void DeleteObj(int i)
    {
        objImage[i].GetComponent<Image>().sprite = transparent;
    }

    IEnumerator Changing(float delay) //오브젝트 변경
    {
        while (true)
        {
           changeTrash();
           yield return new WaitForSeconds(delay);
        }
    }
    
     IEnumerator ShakeCoroutine(Image obj) //틀렸을 때 오브젝트 흔들림.
    {
        float t = 1f;
        Vector3 originV = obj.transform.position;
        while (t > 0f)
        {
            t -= 0.1f;
            obj.transform.position = originV + (Vector3)Random.insideUnitCircle * shakePower * t;
            yield return null;
        }
        obj.transform.position = originV;
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        pausePanel.SetActive(false);
    }
    //-----------Music
    private void FirstMusicSetting()
    {
        if (PlayerPrefs.GetString("music_factory") != null)
        {
            if (PlayerPrefs.GetString("music_factory") == "true")
            {
                music_bool = true;
                Music.GetComponent<AudioSource>().Play();
            }
            else
            {
                music_bool = false;
                Music.GetComponent<AudioSource>().Stop();
            }
        }
        else
            music_bool = true;

        if (PlayerPrefs.GetString("sound_factory") != null)
        {
            if (PlayerPrefs.GetString("sound_factory") == "true")
                sound_bool = true;
            else
                sound_bool = false;
        }
        else
            sound_bool = true;


        GetComponent<AudioSource>().Stop();
    }

    public void ClickMusicBtn()
    {
        if (music_bool)
        {
            music_bool = false;
            PlayerPrefs.SetString("music_factory", "false");
            PlayerPrefs.Save();
            Music.GetComponent<AudioSource>().Stop();
        }
        else
        {
            PlayerPrefs.SetString("music_factory", "true");
            PlayerPrefs.Save();
            music_bool = true;
            Music.GetComponent<AudioSource>().Play();
        }
    }

    public void ClickSoundBtn()
    {
        if (sound_bool)
        {
            sound_bool = false;
            PlayerPrefs.SetString("sound_factory", "false");
            PlayerPrefs.Save();

            //SoundManger 호출
        }
        else
        {
            sound_bool = true;
            PlayerPrefs.SetString("sound_factory", "true");
            PlayerPrefs.Save();
        }
    }
    //----DB
    public void SetSCoreDB()
    {
        RealtimeDatabase.Instance.SetGameScore("score_factory", score);
    }
}
