using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    
    public Text rankNick1, rankNick2, rankNick3;
    public Text rankscore1, rankscore2, rankscore3;
    
    private static RankingManager instance;

    public static RankingManager Instance
    {
        get { return instance; }
    }
    
    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickCashierRank()
    {
        RealtimeDatabase.Instance.GetCashierRank();
    }

    public void UpdateRankBoard(int rank, string nickname, int score)
    {
        Debug.Log(GameObject.Find("Rank1").GetComponent<Text>().text);
        GameObject.Find("Rank1").SetActive(false);
        switch (rank)
        {
            case 1:
                rankNick1.text = nickname;
                rankscore1.text = score.ToString();
                break;
            case 2:
                rankNick2.text = nickname;
                rankscore2.text = score.ToString();
                break;
            case 3:
                rankNick3.text = nickname;
                rankscore3.text = score.ToString();
                break;    
        }
        
        Debug.Log("2. Rank: " + rank + ",Nickname: " + nickname + ", score: " + score);
    }
}
