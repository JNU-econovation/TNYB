using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject tile_yellow, tile_green, tile_blue, tile_gray;
    public GameObject bed_blue, bed_red, bed_purple;
    public GameObject pctable, table_2, tv_table, pctable_blue, pctable_red;
    public GameObject sofa_red, sofa2_red, sofa_blue, sofa2_blue, sofa_green, sofa2_green;
    public GameObject computer, TV;
    public GameObject rug, trashcan, lamp, closet, library;
    public GameObject picture_yellow, picture_red, picture_blue;
    public GameObject chair_gray, chair_red, chair_blue;
    public GameObject door; //문 포함 32개
    private bool[] itemButton = new bool[31];

    public GameObject ItemInventory;
    public GameObject ButtonPanel;
    public GameObject SelectGamePanel;
    public GameObject RankingPanel;
    public GameObject PurchasePanel;
    public int gameMoney = 10000;
    
    private void Start()
    {
        //PurchasePanel.SetActive(false);
        door.SetActive(true);
    }
    public void OpenRankingPanel()
    {
        RankingPanel.SetActive(true);
        ButtonPanel.SetActive(false);
    }
    public void CloseRankingPanel()
    {
        RankingPanel.SetActive(false);
        ButtonPanel.SetActive(true);
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
        ButtonPanel.SetActive(false);
    }
    public void CloseInventory()
    {
        ItemInventory.SetActive(false);
        ButtonPanel.SetActive(true);
    }
    public void ItemPurchase()
    {
         bed_red.SetActive(true);
         //table.SetActive(true);
    }
    public void OpenPurchasePanel()
    {
        PurchasePanel.SetActive(true);
    }
    public void ClosePurchasePanel()
    {
        PurchasePanel.SetActive(false);
    }

    //타일 설정 함수
    void SetTile_Yellow()
    {
        tile_yellow.SetActive(true);
        tile_blue.SetActive(false);
        tile_gray.SetActive(false);
        tile_green.SetActive(false);
    }
    void UnSetTile_Yellow(){tile_yellow.SetActive(false);}

    void SetTile_Gray()
    {
        tile_yellow.SetActive(false);
        tile_blue.SetActive(false);
        tile_gray.SetActive(true);
        tile_green.SetActive(false);
    }
    void UnSetTile_Gray(){tile_gray.SetActive(false);}

    void SetTile_Green()
    {
        tile_yellow.SetActive(false);
        tile_blue.SetActive(false);
        tile_gray.SetActive(false);
        tile_green.SetActive(true);
    }
    void UnSetTile_Green(){tile_green.SetActive(false);}

    void SetTile_Blue()
    {
        tile_yellow.SetActive(false);
        tile_blue.SetActive(true);
        tile_gray.SetActive(false);
        tile_green.SetActive(false);
    }
    void UnSetTile_Blue(){tile_blue.SetActive(false);}

    //침대 설정 함수
    void SetBed_Blue()
    {
        bed_red.SetActive(false);
        bed_blue.SetActive(true);
        bed_purple.SetActive(false);
    }
    void UnSetBed_Blue(){bed_blue.SetActive(false);}

    void SetBed_Red()
    {
        bed_red.SetActive(true);
        bed_blue.SetActive(false);
        bed_purple.SetActive(false);
    }
    void UnSetBed_Red(){bed_red.SetActive(false);}

    void SetBed_PurPle()
    {
        bed_red.SetActive(false);
        bed_blue.SetActive(false);
        bed_purple.SetActive(true);
    }
    void UnSetBed_Purple(){bed_purple.SetActive(false);}

    //table 설정 함수
    void SetPCTable()
    {
        pctable.SetActive(true);
        pctable_red.SetActive(false);
        pctable_blue.SetActive(false);
    }
    void UnSetPCTable(){pctable.SetActive(false);}

    void SetPCTable_Red(){
        pctable.SetActive(false);
        pctable_red.SetActive(true);
        pctable_blue.SetActive(false);
    }
    void UnSetPCTable_Red(){pctable_red.SetActive(false);}

    void SetPCTable_Blue()
    {
        pctable.SetActive(false);
        pctable_red.SetActive(false);
        pctable_blue.SetActive(true);
    }
    void UnSetPCTable_Blue(){pctable_blue.SetActive(false);}

    void SetTVTable(){tv_table.SetActive(true);}
    void UnSetTVTable(){tv_table.SetActive(false);}

    void SetTable2(){table_2.SetActive(true);}
    void UnSetTable2(){table_2.SetActive(false);}

    // 소파 설정 함수
    void SetSofa_Red()
    {
        sofa_red.SetActive(true);
        sofa_blue.SetActive(false);
        sofa_green.SetActive(false);
    }
    void UnSetSofa_Red(){sofa_red.SetActive(false);}

    void SetSofa_Blue()
    {
        sofa_red.SetActive(false);
        sofa_blue.SetActive(true);
        sofa_green.SetActive(false);
    }
    void UnSetSofa_Blue(){sofa_blue.SetActive(false);}

    void SetSofa_Green()
    {
        sofa_red.SetActive(false);
        sofa_blue.SetActive(false);
        sofa_green.SetActive(true);
    }
    void UnSetSofa_Green(){sofa_green.SetActive(false);}

    void SetSofa2_Red()
    {
        sofa2_red.SetActive(true);
        sofa2_blue.SetActive(false);
        sofa2_green.SetActive(false);
    }
    void UnSetSofa2_Red() { sofa2_red.SetActive(false);}

    void SetSofa2_Blue()
    {
        sofa2_red.SetActive(false);
        sofa2_blue.SetActive(true);
        sofa2_green.SetActive(false);
    }
    void UnSetSofa2_Blue(){ sofa2_blue.SetActive(false);}

    void SetSofa2_Green()
    {
        sofa2_red.SetActive(false);
        sofa2_blue.SetActive(false);
        sofa2_green.SetActive(true);
    }
    void UnSetSofa2_Green(){sofa2_green.SetActive(false);}

    //기타 설정 함수
    void SetTv(){TV.SetActive(true);}
    void UnSetTV() { TV.SetActive(false); }

    void SetComputer(){computer.SetActive(true);}
    void UnSetComputer() { computer.SetActive(false); }

    void SetRug(){rug.SetActive(true);}
    void UnSetRug() { rug.SetActive(false); }

    void SetTrashCan(){trashcan.SetActive(true);}
    void UnSetTrashCan() { trashcan.SetActive(false); }

    void SetLamp(){lamp.SetActive(true);}
    void UnSetLamp() { lamp.SetActive(false); }

    void SetCloset(){closet.SetActive(true);}
    void UnSetCloset() { closet.SetActive(false); }

    void SetLibrary(){library.SetActive(true);}
    void UnSetLibrary() { library.SetActive(false); }

    //액자 설정 함수
    void SetPicture_Yellow()
    {
        picture_yellow.SetActive(true);
        picture_red.SetActive(false);
        picture_blue.SetActive(false);
    }
    void UnSetPicture_yellow() { picture_yellow.SetActive(false); }

    void SetPicture_Red()
    {
        picture_yellow.SetActive(false);
        picture_red.SetActive(true);
        picture_blue.SetActive(false);
    }
    void UnSetPicture_red() { picture_red.SetActive(false); }

    void SetPicture_Blue()
    {
        picture_yellow.SetActive(false);
        picture_red.SetActive(false);
        picture_blue.SetActive(true);
    }
    void UnSetPicture_blue() { picture_blue.SetActive(false); }

    //의자 설정 함수
    void SetChair_Gray()
    {
        chair_red.SetActive(false);
        chair_blue.SetActive(false);
        chair_gray.SetActive(true);
    }
    void UnSetChair_Gray() { chair_gray.SetActive(false); }

    void SetChair_Blue()
    {
        chair_red.SetActive(false);
        chair_blue.SetActive(true);
        chair_gray.SetActive(false);
    }
    void UnSetChair_Blue() { chair_blue.SetActive(false); }

    void SetChair_Red()
    {
        chair_red.SetActive(true);
        chair_blue.SetActive(false);
        chair_gray.SetActive(false);
    }
    void UnSetChair_Red() { chair_red.SetActive(false); }
}
