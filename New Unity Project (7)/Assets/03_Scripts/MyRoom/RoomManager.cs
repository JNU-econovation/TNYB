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
    public GameObject door;

   
    public GameObject ItemInventory;
    public GameObject ButtonPanel;
    public GameObject SelectGamePanel;
    public GameObject RankingPanel;
    public GameObject PurchasePanel;
    public int gameMoney = 10000;
    
    private void Start()
    {
        //PurchasePanel.SetActive(false);
        //door.SetActive(true);
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
    public void SetTile_Yellow()
    {
        tile_yellow.SetActive(true);
        tile_blue.SetActive(false);
        tile_gray.SetActive(false);
        tile_green.SetActive(false);
    }
    public void SetTile_Gray()
    {
        tile_yellow.SetActive(false);
        tile_blue.SetActive(false);
        tile_gray.SetActive(true);
        tile_green.SetActive(false);
    }
    public void SetTile_Green()
    {
        tile_yellow.SetActive(false);
        tile_blue.SetActive(false);
        tile_gray.SetActive(false);
        tile_green.SetActive(true);
    }
    public void SetTile_Blue()
    {
        tile_yellow.SetActive(false);
        tile_blue.SetActive(true);
        tile_gray.SetActive(false);
        tile_green.SetActive(false);
    }

    //침대 설정 함수
    public void SetBed_Blue()
    {
        bed_red.SetActive(false);
        bed_blue.SetActive(true);
        bed_purple.SetActive(false);
    }
    public void SetBed_Red()
    {
        bed_red.SetActive(true);
        bed_blue.SetActive(false);
        bed_purple.SetActive(false);
    }
    public void SetBed_PurPle()
    {
        bed_red.SetActive(false);
        bed_blue.SetActive(false);
        bed_purple.SetActive(true);
    }

}
