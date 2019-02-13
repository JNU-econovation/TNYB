using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_TransitionManager : MonoBehaviour
{
    public GameObject FadeStartPanel;
    public float fadeStartDuration;
    public GameObject FadeEndPanel;
    public float fadeEndDuration;

    private void Awake()
    {
        FadeEndPanel.SetActive(false);
        if (Application.loadedLevel != 0)
        {
            FadeStart(fadeStartDuration);
        }
    }

    IEnumerator LoadMyRoom(float fadeStartDuration)
    {
        yield return new WaitForSeconds(fadeStartDuration);
        FadeStartPanel.SetActive(false);
    }

    public void FadeStart(float fadeStartDuration)
    {
        FadeStartPanel.SetActive(true);
        StartCoroutine(LoadMyRoom(fadeStartDuration));
    }

    public void FadeEndtoScene(string sceneName)
    {
        FadeEndPanel.SetActive(true);
        playClick();
        StartCoroutine(LoadScene(sceneName, fadeEndDuration));
    }

    IEnumerator LoadScene(string sceneName, float fadeEndDuration)
    {
        yield return new WaitForSeconds(fadeEndDuration);
        SceneManager.LoadScene(sceneName);
    }

    public void playClick()
    {
        switch (Application.loadedLevel)
        {
            case 0:
                SfxManager.Instance.playClick();
                break;
            case 1:
                myRoomSfxManager.Instance.playClick();
                break;
            case 5:
                selectGameSfxManager.Instance.playClick();
                break;
        }
    }
}
