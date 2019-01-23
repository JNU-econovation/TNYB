using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScenes : MonoBehaviour
{
    // Start is called before the first frame update
    public void ToFirstScene()
    {
        SceneManager.LoadScene(0);
    }
    public void ToMain_aka_Exit()
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
}
