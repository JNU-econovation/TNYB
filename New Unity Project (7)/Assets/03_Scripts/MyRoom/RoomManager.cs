using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject tile_yellow, tile_green, tile_blue, tile_gray;
    public GameObject bed_blue, bed_red;
    public GameObject table_1, table_2, tv_table, table_blue;
    public GameObject sofa_1, sofa_2, sofa_blue, sofa2_blue;
    public GameObject computer, TV;
    public GameObject rug, trashcan, lamp, closet, library;
    public GameObject picture, picture_red;
    public GameObject chair_gray, chair_red;
    public GameObject door;

    private void Start()
    {
        door.SetActive(true);
    }
}
