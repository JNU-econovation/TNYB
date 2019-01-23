using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScenes : MonoBehaviour
{
    // Start is called before the first frame update
    public void ToMain()
    {
        SceneManager.LoadScene(0);
    }
    public void ToFactory()
    {
        SceneManager.LoadScene(3);
    }
    public void ToCinema()
    {
        SceneManager.LoadScene(2);
    }
    public void ToMart()
    {
        SceneManager.LoadScene(1);
    }
}
