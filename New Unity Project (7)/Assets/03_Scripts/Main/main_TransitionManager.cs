using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_TransitionManager : MonoBehaviour
{
    public GameObject transitionPanel;
    public GameObject FadeStartTransitionPanel;

    private void Awake()
    {
        transitionPanel.SetActive(false);
        if (Application.loadedLevel != 0)
        {
            FadeStartTransitionPanel.SetActive(true);
            StartCoroutine(LoadMyRoom());    
        }
    }

    IEnumerator LoadMyRoom()
    {
        yield return new WaitForSeconds(3.0f);
        FadeStartTransitionPanel.SetActive(false);
    }

    public void toScene(string sceneName)
    {
        transitionPanel.SetActive(true);
        playClick();
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(sceneName);
    }

    public void playClick()
    {
        if (Application.loadedLevel == 0)
        {
            SfxManager.Instance.playClick();
        }
        else if(Application.loadedLevel == 1)
        {
            myRoomSfxManager.Instance.playClick();
        }
    }
}
