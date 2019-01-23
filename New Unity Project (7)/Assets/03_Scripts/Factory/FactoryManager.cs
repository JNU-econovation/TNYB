using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryManager : MonoBehaviour {

    public Sprite transparent;
    public ParticleSystem particle;
    public static FactoryManager Instance;
    private bool isPaused = false;
    public Image selector;
    private string[] kind = {"pet", "pet", "pet", "paper",
        "paper", "paper", "bottle", "bottle", "bottle",
        "can","can","can","pet","paper", "bottle", "can"};

    public Image[] objImage = new Image[8]; //세팅된 이미지
    public Text scoreText;
    private int score = 0;
    private int clickCount;
    public Text comboText;

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

    public GameObject pausePanel;
    public GameObject gameOverPanel;
    private bool combo = false;

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
    }
    // Use this for initialization
    void Start() {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        StartCoroutine(Changing(speed));
        comboText.text = "";
        makeTrash_1();


        timer = 0.0f;
        waitingTime = 1.5f;

    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            if (combo)
            {
                if (a)
                {
                    comboText.text = "X2";
                    a = false;
                }
                else
                {
                    comboText.text = "";
                    a = true;
                }
            }
            else
                comboText.text = "";
            timer = 0;
        }

        left += 1f;
        right += 1f;
        if(left > 1000)
        {
            left = right = 0;
        }
        selector.GetComponent<RectTransform>().offsetMin = new Vector2(left, 0);//left-bottom
        selector.GetComponent<RectTransform>().offsetMax = new Vector2(right, 0);//right-top
        
    }

    void UpScore() //점수 업
    {
        if (combo)
            score += 200;
        else
            score += 100;
        scoreText.text =  score.ToString();
        
    }

    void DownScore() //점수 다운
    {
        combo = false;
        if(score > 10)
        {
            score -= 50;
            scoreText.text = score.ToString();
        }
        else
        {
            scoreText.text = "Score : 0";
        }
        speed = 4.0f;
        
    }
   void setSelector() //위에 pet, can, bottle, paper 선택창 세팅
    {
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
            if (clickCount == 0)
                combo = true;
            int ran = Random.Range(0, 8);
            int tmpran;
            while (true)
            {
                tmpran = Random.Range(0, 16);
                if (kind[tmpran] == select) break;
            }
            objImage[ran].GetComponent<Image>().sprite = trashImage[tmpran];
            count++;
        }
    }  
    public void ItemDestroy(int i)
    {
        if(objImage[i].GetComponent<Image>().sprite != transparent)
        {
            clickCount -= 1;
            if ( kind[num[i]] == select)
            {
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
        int a, b;
        a = Random.Range(0, 8);
        b = Random.Range(0, 8);
        while(a==b)
            b = Random.Range(0, 8);
        if (objImage[a].GetComponent<Image>().sprite !=transparent
            && objImage[b].GetComponent<Image>().sprite != transparent)
        {
            objImage[a].GetComponent<Image>().sprite = trashImage[num[b]];
            objImage[b].GetComponent<Image>().sprite = trashImage[num[a]];

            int tmpnum = num[b];
            num[b] = num[a];
            num[a] = tmpnum;
        }
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
}
