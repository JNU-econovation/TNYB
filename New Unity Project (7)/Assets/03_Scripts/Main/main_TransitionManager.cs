using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_TransitionManager : MonoBehaviour
{
    public GameObject transitionPanel;
    public Animator transitionAnim;
    public string sceneName;

    private void Awake()
    {
        transitionPanel.SetActive(false);
    }

    public void toMain()
    {
        transitionPanel.SetActive(true);
        SfxManager.Instance.playClick();
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(sceneName);
    }
}
