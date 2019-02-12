using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    
    public Text rankNick1, rankNick2, rankNick3, rankNick4, rankNick5, rankNick6, rankNick7, rankNick8, rankNick9, rankNick10;
    public Text rankscore1, rankscore2, rankscore3, rankscore4, rankscore5, rankscore6, rankscore7, rankscore8, rankscore9, rankscore10;
    public GameObject loading1, loading2, loading3, loading4, loading5, loading6, loading7, loading8, loading9, loading10;
    
    private List<Text> rankNickList = new List<Text>();
    private List<Text> rankScoreList = new List<Text>();
    private List<GameObject> loadingList = new List<GameObject>();
    
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

        setList();        
    }

    public void setList()
    {
        rankNickList.Add(rankNick1);
        rankNickList.Add(rankNick2);
        rankNickList.Add(rankNick3);
        rankNickList.Add(rankNick4);
        rankNickList.Add(rankNick5);
        rankNickList.Add(rankNick6);
        rankNickList.Add(rankNick7);
        rankNickList.Add(rankNick8);
        rankNickList.Add(rankNick9);
        rankNickList.Add(rankNick10);

        rankScoreList.Add(rankscore1);
        rankScoreList.Add(rankscore2);
        rankScoreList.Add(rankscore3);
        rankScoreList.Add(rankscore4);
        rankScoreList.Add(rankscore5);
        rankScoreList.Add(rankscore6);
        rankScoreList.Add(rankscore7);
        rankScoreList.Add(rankscore8);
        rankScoreList.Add(rankscore9);
        rankScoreList.Add(rankscore10);

        loadingList.Add(loading1);
        loadingList.Add(loading2);
        loadingList.Add(loading3);
        loadingList.Add(loading4);
        loadingList.Add(loading5);
        loadingList.Add(loading6);
        loadingList.Add(loading7);
        loadingList.Add(loading8);
        loadingList.Add(loading9);
        loadingList.Add(loading10);
    }

    public void ClickGetRank(string nameOfGame)
    {
        RealtimeDatabase.Instance.GetRank(nameOfGame);
    }

    public void loadingStart()
    {
        for (int i = 0; i <= loadingList.Count; i++)
        {
            loadingList[i].SetActive(true);
        }
    }

    public void loadingEnd()
    {
        for (int i = 0; i <= loadingList.Count; i++)
        {
            loadingList[i].SetActive(false);
        }
    }

    public void UpdateRankBoard(int rank, string nickname, int score)
    {
        int i = rank;
        rankNickList[i].text = nickname;
        rankScoreList[i].text = score.ToString();
        loadingEnd();
        
        /*
        switch (rank)
        {
            case 1:
                rankNick1.text = nickname;
                rankscore1.text = score.ToString();
                loading1.SetActive(false);
                break;
            case 2:
                rankNick2.text = nickname;
                rankscore2.text = score.ToString();
                loading2.SetActive(false);
                break;
            case 3:
                rankNick3.text = nickname;
                rankscore3.text = score.ToString();
                loading3.SetActive(false);
                break;    
        }
        */
    }
}
