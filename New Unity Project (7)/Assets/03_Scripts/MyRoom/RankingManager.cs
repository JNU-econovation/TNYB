using System.Collections;
using System.Collections.Generic;
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

    private const string selectedColor = "60FF06";
    public Text cashierText, cinemaText, factoryText;

    public Scrollbar rankScrollbar;
    
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
        myRoomSfxManager.Instance.playClick();
        changeNameColor(nameOfGame);
        rankScrollbar.value = 1;
        loading();
        RealtimeDatabase.Instance.GetRank(nameOfGame);
    }

    private void changeNameColor(string nameOfGame)
    {
        switch (nameOfGame)
        {
            case "cashier":
                cashierText.color = GetColorFromString(selectedColor);
                cinemaText.color = Color.white;
                factoryText.color = Color.white;
                break;
            case "cinema":
                cinemaText.color = GetColorFromString(selectedColor);
                cashierText.color = Color.white;
                factoryText.color = Color.white;
                break;
            case "factory":
                factoryText.color = GetColorFromString(selectedColor);
                cinemaText.color = Color.white;
                cashierText.color = Color.white;
                break;
        }
    }

    public void loading()
    {
        deleteNicknameScore();
        loadingStart();

    }

    public void deleteNicknameScore()
    {
        for (int i = 0; i < rankNickList.Count; i++)
        {
            rankNickList[i].text = "";
        }
        
        for (int i = 0; i < rankScoreList.Count; i++)
        {
            rankScoreList[i].text = "";
        }
    }

    public void loadingStart()
    {
        for (int i = 0; i < loadingList.Count; i++)
        {
            loadingList[i].SetActive(true);
        }
    }

    public void loadingEnd()
    {
        for (int i = 0; i < loadingList.Count; i++)
        {
            loadingList[i].SetActive(false);
        }
    }

    public void UpdateRankBoard(int rank, string nickname, int score)
    {
        // int i = rank - 1;
        int i = rank - 1;
        if (nickname == null)
        {
            rankNickList[i].text = "ERROR";
            rankScoreList[i].text = "ERROR";
            loadingEnd();
            return;
        }
        
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
    
    private int HexToDec(string hex)
    {
        int dec = System.Convert.ToInt32(hex, 16);
        return dec;
    }

    private float HexToFloatNormalized(string hex)
    {
        return HexToDec(hex) / 255f;
    }

    private Color GetColorFromString(string HexString)
    {
        float red = HexToFloatNormalized(HexString.Substring(0, 2));
        float green = HexToFloatNormalized(HexString.Substring(2, 2));
        float blue = HexToFloatNormalized(HexString.Substring(4, 2));
        return new Color(red, green, blue);
    }
}
