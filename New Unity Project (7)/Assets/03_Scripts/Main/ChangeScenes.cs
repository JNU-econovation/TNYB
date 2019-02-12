using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class ChangeScenes : MonoBehaviour
{
    public void ToSelectGame()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }
    
    public void ToFirstScene()
    {
        SceneManager.LoadScene(0);
    }
    public void ToMyRoom()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void ToFactory()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }
    public void ToCinema()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }
    public void ToMart()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

    private bool myroom_bool;
    public void ClickMyRoom()
    {
        if (myroom_bool)
        {
            myroom_bool = false;
        }
        else
        {
            myroom_bool = true;
        }
    }


}
