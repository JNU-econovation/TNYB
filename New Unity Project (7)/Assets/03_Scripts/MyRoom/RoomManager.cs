using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RoomManager : MonoBehaviour
{
    private static RoomManager instance;

    public static RoomManager Instance
    {
        get { return instance; }
    }

    public Text RoomNameText;
    public Text GameMoneyText;
    public GameObject nomenyText;

    public GameObject[] tile = new GameObject[4];// 0: yellow, 1: green, 2: blue, 3: gray===0-3
    public GameObject[] bed = new GameObject[3]; //0: red, 1: blue, 2: purple=== 4-6
    public GameObject[] table = new GameObject[5]; //0: pc-table_gray 1: pc-table_red 2: pc-table_blue 3: table_2 4: tv-table;=== 7-11
    public GameObject[] sofa = new GameObject[6]; // 0: sofa_red, 1:sofa_blue 2: sofa_green 3: sofa2_red, 4: sofa2_blue, 5: sofa2_green;=== 12-17
    public GameObject[] chair = new GameObject[3]; //0: chair_gray, 1: chair_red, 2:chair_blue ===//18 - 20
    public GameObject[] picture = new GameObject[3]; //0: picture_yellow, 1:picture_red, 2:picture_blue=== 21-23
    public GameObject[] appliance = new GameObject[3]; //0: computer, 1:tv, 2:lamp=== 24-26
    public GameObject[] etc = new GameObject[2]; //0: trashcan 1: rug=== 27-28
    public GameObject[] furniture = new GameObject[2]; //0: closet, 1: library=== 29 - 30
    //public GameObject door; //문 포함 32개

    public bool[] purchase = new bool[31]; // 위 코드 순서 false 노구매 true 구매
    private int[] price = new int[31];
    public Text priceText;
    private void setprice()
    {
        price[0] = price[1] = price[2] = price[3] = 200000;
        price[4] = price[5] = price[6] = 250000;
        price[7] = price[8] = price[9] = 100000;
        price[10] = 50000;
        price[11] = 300000;
        price[12] = price[13] = price[14] = 4700000;
        price[15] = price[16] = price[17] = 2200000;
        price[18] = price[19] = price[20] = 50000;
        price[21] = price[22] = price[23] = 1000000;
        price[24] = 800000;
        price[25] = 1500000;
        price[26] = 25000;

        price[27] = 150000;
        price[28] = 50000;
        price[29] = 10000;
        price[30] = 17000;
    }

    public bool[] tile_bool = new bool[4]; // 0: yellow, 1: green, 2: blue, 3: gray
    public bool[] bed_bool = new bool[3]; // 0: red, 1: blue, 2: purple
    public bool[] table_bool = new bool[5]; //0: pc-table_gray 1: pc-table_blue 2: pc-table_red 3: table_2 4: tv-table;
    public bool[] sofa_bool = new bool[6]; // 0: sofa_red, 1:sofa_blue 2: sofa_green 3: sofa2_red, 4: sofa2_blue, 5: sofa2_green;
    public bool[] chair_bool = new bool[3]; //0: chair_gray, 1: chair_red, 2:chair_blue
    public bool[] picture_bool = new bool[3];//0: picture_yellow, 1:picture_red, 2:picture_blue
    public bool[] appliance_bool = new bool[3];//0: computer, 1:tv, 2:lamp
    public bool[] furniture_bool = new bool[2];
    public bool[] etc_bool = new bool[2]; //0:trashcan 1: rug

    private int Button_number;

    public Sprite[] ButtonImage = new Sprite[2];
    private bool[] settingButtons_bool = new bool[3];
    public Button[] settingButton = new Button[3];
    public GameObject SettingPaenl;

    public GameObject ItemInventory;
    public GameObject ButtonPanel;
    public GameObject SelectGamePanel;
    public GameObject RankingPanel;
    public GameObject PurchasePanel;
    public int gameMoney = 10000;
    private void Awake()
    {
        //if (instance)
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        instance = this;
        setprice();
        Time.timeScale = 1;
    }

    private void Start()
    {
        settingButtons_bool[0] = settingButtons_bool[1] = settingButtons_bool[2] = true;
        Button_number =-1;
        PurchasePanel.SetActive(false);
        //  door.SetActive(true);
        RealtimeDatabase.Instance.GetMoneyDB();
        RealtimeDatabase.Instance.GetpurchaseDB();
        RealtimeDatabase.Instance.SetRoomDB();
        RealtimeDatabase.Instance.setRoomName();
    }

    public void setRoomName(string roomName)
    {
        string roomTitle = roomName + "의 행복한 자취방";
        RoomNameText.text = roomTitle;
    }
    
    public void OpenSettingPanel()
    {
        SettingPaenl.SetActive(true);
    }

    public void ClickSettingButton()
    {
        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';

        if (settingButtons_bool[a])
        {
            if(a== 0)
            {
                myroomSFX.Instance.isMfxMute = true;
                PlayerPrefs.SetInt("isMfxMute", 1);
                PlayerPrefs.Save();
                myroomSFX.Instance.setMyRoomMusic();
            }
            settingButton[a].GetComponent<Image>().sprite = ButtonImage[0];
            settingButtons_bool[a] = false;
        }
        else
        {
            if (a == 0)
            {
                myroomSFX.Instance.isMfxMute = false;
                PlayerPrefs.SetInt("isMfxMute", 0);
                PlayerPrefs.Save();
                myroomSFX.Instance.setMyRoomMusic();
            }
            settingButton[a].GetComponent<Image>().sprite = ButtonImage[1];
            settingButtons_bool[a] = true;
        }
    }
    public void CloseSettingPanel()
    {
        SettingPaenl.SetActive(false);
    }
    public void OpenRankingPanel()
    {
        RankingPanel.SetActive(true);
        RankingManager.Instance.ClickGetRank("cashier");
    }
    public void CloseRankingPanel()
    {
        RankingPanel.SetActive(false);
        //ButtonPanel.SetActive(true);
    }
    public void OpendSelectGame()
    {
        SelectGamePanel.SetActive(true);
        ButtonPanel.SetActive(false);
    }
    public void CloseSlelectGame()
    {
        SelectGamePanel.SetActive(false);
        ButtonPanel.SetActive(true);
    }

    public void OpenInventory()
    {
        ItemInventory.SetActive(true);
        //ButtonPanel.SetActive(false);
    }
    public void CloseInventory()
    {
        ItemInventory.SetActive(false);
        //ButtonPanel.SetActive(true);
    }
    public void ItemPurchase()
    {
         
         //table.SetActive(true);
    }
    private void OpenPurchasePanel()
    {
        Debug.Log(Button_number);
        priceText.text = "Price : "+price[Button_number].ToString();
        PurchasePanel.SetActive(true);
    }
    public void getMoneyDB(string m)
    {
        int money_tmp = Convert.ToInt32(m);
        gameMoney = money_tmp;
        GameMoneyText.text = m;
    }
    public void ClosePurchasePanel()
    {
        PurchasePanel.SetActive(false);
        nomenyText.SetActive(false);
    }
    public void SuccessPurshcase()
    {

        if(gameMoney> price[Button_number])
        {
            PurchasePanel.SetActive(false); purchase[Button_number] = true;
            RealtimeDatabase.Instance.SetMoneyData(gameMoney - price[Button_number]);
            gameMoney = gameMoney - price[Button_number];
            GameMoneyText.text = gameMoney.ToString();
            RealtimeDatabase.Instance.SetPurchaseData("MyRoom_purchase", Button_number);
        }
        else
        {
            nomenyText.SetActive(true);
        }

    }
    //=========================================
    //타일 설정 함수
    void SetTile(int a)
    {
        for (int i = 0; i < tile.Length; i++)
            tile[i].SetActive(false);
        tile[a].SetActive(true);
    }
    void UnSetTile(int a){tile[a].SetActive(false);}

    //침대 설정 함수
    void SetBed(int a)
    {
        for (int i = 0; i < bed.Length; i++)
            bed[i].SetActive(false);
        bed[a].SetActive(true);
    }
    void UnSetBed(int a){bed[a].SetActive(false);}

    //table 설정 함수
    void SetTable(int a)
    {
        if (a < 3)
        {
            for (int i = 0; i < 3; i++)
                table[i].SetActive(false);
            table[a].SetActive(true);
        }
        else
        {
            table[a].SetActive(true);
        }
    }
    void UnSetTable(int a){table[a].SetActive(false);}

    // 소파 설정 함수
    void SetSofa(int a)
    {
        if (a < 3)
        {
            for (int i = 0; i < 3; i++)
                sofa[i].SetActive(false);
            sofa[a].SetActive(true);
        }
        else
        {
            for (int i = 3; i < sofa.Length; i++)
                sofa[i].SetActive(false);
            sofa[a].SetActive(true);
        }


    }
    void UnSetSofa(int a){sofa[a].SetActive(false);}

    //의자 설정 함수
    void SetChair(int a)
    {
        for (int i = 0; i < chair.Length; i++)
            chair[i].SetActive(false);
        chair[a].SetActive(true);
    }
    void UnSetChair(int a){chair[a].SetActive(false);}

    //액자 설정 함수
    void SetPicture(int a)
    {
        for (int i = 0; i < picture.Length; i++)
            picture[i].SetActive(false);
        picture[a].SetActive(true);
    }
    void UnSetPicture(int a) { picture[a].SetActive(false); }

    //전자기기 설정 함수
    void SetAppliance(int a){appliance[a].SetActive(true);}
    void UnSetAppliance(int a) { appliance[a].SetActive(false); }

    //가구 설정 함수
    void SetFurniture(int a){furniture[a].SetActive(true);}
    void UnSetFurniture(int a) { furniture[a].SetActive(false); }

    //기타 설정 함수
    void SetEtc(int a){etc[a].SetActive(true);}
    void UnSetEtc(int a) { etc[a].SetActive(false); }

    //==================================================
    //클릭 함수
    public void ClickButton_Tile()
    {
        
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);

        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';

        if (purchase[a]) //구매했을때
        {
            if (tile_bool[a])
            {
                tile_bool[a] = false;
                UnSetTile(a);
            }
            else
            {
                SetTile(a);
                tile_bool = new bool[4];
                tile_bool[a] = true;
            }
            RealtimeDatabase.Instance.SetMyRoomData("MyRoom_tile", tile_bool);
        }
        else //구매 안했을때
        {
            Button_number = a;
            OpenPurchasePanel();
        }
    }
    public void ClickButton_Bed()
    {
        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';

        if (!purchase[a + 4])
        {
            Button_number = a + 4;
            OpenPurchasePanel();
        }
        else
        {
            if (bed_bool[a])
            {
                bed_bool[a] = false;
                UnSetBed(a);
            }
            else
            {
                bed_bool = new bool[3];
                bed_bool[a] = true;
                SetBed(a);
            }
            RealtimeDatabase.Instance.SetMyRoomData("MyRoom_bed", bed_bool);
        }
    }
    public void ClickButton_Table()
    {
        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';

        if (!purchase[a + 7])
        {
            Button_number = a + 7;
            OpenPurchasePanel();
        }
        else
        {
            if (table_bool[a])
            {
                table_bool[a] = false;
                UnSetTable(a);
            }
            else
            {
                if (a < 3)
                    for (int i = 0; i < 3; i++)
                        table_bool[i] = false;

                table_bool[a] = true;

                SetTable(a);
            }
            RealtimeDatabase.Instance.SetMyRoomData("MyRoom_table", table_bool);
        }
    }
    public void ClickButton_Sofa()
    {

        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';
        
        if (!purchase[a + 12])
        {
            Button_number = a + 12;
            OpenPurchasePanel();
        }
        else
        {
            if (sofa_bool[a])
            {
                sofa_bool[a] = false;
                UnSetSofa(a);
            }
            else
            {
                if (a < 3)
                {
                    for (int i = 0; i < 3; i++)
                        sofa_bool[i] = false;
                }
                else
                {
                    for (int i = 3; i < 6; i++)
                        sofa_bool[i] = false;
                }
                sofa_bool[a] = true;
                SetSofa(a);
            }
            RealtimeDatabase.Instance.SetMyRoomData("MyRoom_sofa", sofa_bool);
        }
    }
    public void ClickButton_Chair()
    {
        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';

        if (!purchase[a + 18])
        {
            Button_number = a + 18;
            OpenPurchasePanel();
        }
        else
        {
            if (chair_bool[a])
            {
                chair_bool[a] = false;
                UnSetChair(a);
            }
            else
            {
                chair_bool = new bool[3];
                chair_bool[a] = true;
                SetChair(a);
            }
            RealtimeDatabase.Instance.SetMyRoomData("MyRoom_chair", chair_bool);
        }
    }
    public void ClickButton_Picture()
    {
        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';

        if (!purchase[a + 21])
        {
            Button_number = a + 21;
            OpenPurchasePanel();
        }
        else
        {
            if (picture_bool[a])
            {
                picture_bool[a] = false;
                UnSetPicture(a);
            }
            else
            {
                picture_bool = new bool[3];
                picture_bool[a] = true;
                SetPicture(a);
            }
            RealtimeDatabase.Instance.SetMyRoomData("MyRoom_picture", picture_bool);
        }
    }
    public void ClickButton_Appliance()
    {
        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';
        if (!purchase[a + 24])
        {
            Button_number = a + 24;
            OpenPurchasePanel();
        }
        else
        {
            if (appliance_bool[a])
            {
                appliance_bool[a] = false;
                UnSetAppliance(a);
            }
            else
            {
                appliance_bool[a] = true;
                SetAppliance(a);
            }
            RealtimeDatabase.Instance.SetMyRoomData("MyRoom_appliance", appliance_bool);
        }
    }
    public void ClickButton_Furniture()
    {
        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';

        if (!purchase[a + 27])
        {
            Button_number = a + 27;
            OpenPurchasePanel();
        }
        else
        {
            if (furniture_bool[a])
            {
                furniture_bool[a] = false;
                UnSetFurniture(a);
            }
            else
            {
                furniture_bool[a] = true;
                SetFurniture(a);
            }
            RealtimeDatabase.Instance.SetMyRoomData("MyRoom_furniture", furniture_bool);
        }
    }
    public void ClickButton_Etc()
    {
        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';

        if (!purchase[a + 29])
        {
            Button_number = a + 29;
            OpenPurchasePanel();
        }
        {
            if (etc_bool[a])
            {
                etc_bool[a] = false;
                UnSetEtc(a);
            }
            else
            {
                etc_bool[a] = true;
                SetEtc(a);
            }
            RealtimeDatabase.Instance.SetMyRoomData("MyRoom_etc", etc_bool);
        }
    }


    //=======================================================
    //DB
    public void SettingRoom()
    {
        for (int i = 0; i < tile_bool.Length; i++)
            if (tile_bool[i])
                tile[i].SetActive(true);

        for (int i = 0; i < bed_bool.Length; i++)
            if (bed_bool[i])
                bed[i].SetActive(true);

        for (int i = 0; i < table_bool.Length; i++)
            if (table_bool[i])
                table[i].SetActive(true);

        for (int i = 0; i < sofa_bool.Length; i++)
            if (sofa_bool[i])
                sofa[i].SetActive(true);

        for (int i = 0; i < chair_bool.Length; i++)
            if (chair_bool[i])
                chair[i].SetActive(true);

        for (int i = 0; i < picture_bool.Length; i++)
            if (picture_bool[i])
                picture[i].SetActive(true);

        for (int i = 0; i < appliance_bool.Length; i++)
            if (appliance_bool[i])
                appliance[i].SetActive(true);

        for (int i = 0; i < furniture_bool.Length; i++)
            if (furniture_bool[i])
                furniture[i].SetActive(true);

        for (int i = 0; i < etc_bool.Length; i++)
            if (etc_bool[i])
                etc[i].SetActive(true);


    }
    public void TruePurchase(int i)
    {
        purchase[i] = true;
    }

}
