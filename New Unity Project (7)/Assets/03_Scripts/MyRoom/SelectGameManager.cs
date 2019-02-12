using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectGameManager : MonoBehaviour
{
    public GameObject martTutorialPanel;
    public GameObject cinemaTutorialPanel;
    public GameObject factoryTutorialPanel;
    public Button Cinema_prevBtn;
    public Button Cinema_nextBtn;
    public Button Mart_prevBtn;
    public Button Mart_nextBtn;
    public GameObject fakeTicket;
    public GameObject Ticekt;
    public GameObject hand1;
    public GameObject hand2;
    public GameObject redline;
    public GameObject CineTutoText;
    public GameObject Mart_Tuto1;
    public GameObject Mart_Tuto2;
    //Factory
    public GameObject RedImage;
    public Button Factory_nextBtn;
    public Button Factory_prevBtn;
    public GameObject[] animation_0 = new GameObject[2];
    public GameObject animation_1;

    void Start()
    {
        Cinema_prevBtn.interactable = false;
        Mart_prevBtn.interactable = false;
    }

    public void CinemaTutorialPanel_Open()
    {
        Cinema_nextBtn.interactable = true;
        Cinema_prevBtn.interactable = false;
        selectGameSfxManager.Instance.playClick();
        cinemaTutorialPanel.SetActive(true);
        fakeTicket.SetActive(false);
        hand2.SetActive(false);
        redline.SetActive(false);
        CineTutoText.SetActive(false);
        Ticekt.SetActive(true);
        hand1.SetActive(true);
    }
    public void CinemaTutorialPanel_GamestartBtn()
    {
        selectGameSfxManager.Instance.playStart();
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }
    public void CinemaTutorialPanel_Close()
    {
        selectGameSfxManager.Instance.playBack();
        cinemaTutorialPanel.SetActive(false);
    }
    public void CinemaTutorialPanel_nextBtn()
    {
        Cinema_nextBtn.interactable = false;
        Cinema_prevBtn.interactable = true;
        selectGameSfxManager.Instance.playNext();
        fakeTicket.SetActive(true);
        hand2.SetActive(true);
        redline.SetActive(true);
        CineTutoText.SetActive(true);
        Ticekt.SetActive(false);
        hand1.SetActive(false);
    }
    public void CinemaTutorialPanel_PrevBtn()
    {
        Cinema_nextBtn.interactable = true;
        Cinema_prevBtn.interactable = false;
        selectGameSfxManager.Instance.playNext();
        fakeTicket.SetActive(false);
        hand2.SetActive(false);
        redline.SetActive(false);
        CineTutoText.SetActive(false);
        Ticekt.SetActive(true);
        hand1.SetActive(true);
    }

    /// <summary> 
    /// </summary>

    public void MartTutorialPanel_Open()
    {
        Mart_nextBtn.interactable = true;
        Mart_prevBtn.interactable = false;
        selectGameSfxManager.Instance.playClick();
        martTutorialPanel.SetActive(true);
        Mart_Tuto1.SetActive(true);
        Mart_Tuto2.SetActive(false);
    }
    public void MartTutorialPanel_GamestartBtn()
    {
        selectGameSfxManager.Instance.playStart();
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void MartTutorialPanel_Close()
    {
        selectGameSfxManager.Instance.playBack();
        martTutorialPanel.SetActive(false);
    }
    public void MartTutorialPanel_nextBtn()
    {
        Mart_nextBtn.interactable = false;
        Mart_prevBtn.interactable = true;
        selectGameSfxManager.Instance.playNext();
        Mart_Tuto1.SetActive(false);
        Mart_Tuto2.SetActive(true);

    }
    public void MartTutorialPanel_PrevBtn()
    {
        selectGameSfxManager.Instance.playNext();
        Mart_nextBtn.interactable = true;
        Mart_prevBtn.interactable = false;
        Mart_Tuto1.SetActive(true);
        Mart_Tuto2.SetActive(false);

    }
    /// <summary>
    /// 이하 공장
    /// </summary>
    public void FactoryTutorialPanel_Open()
    {
        Factory_nextBtn.interactable = true;
        Factory_prevBtn.interactable = false;
        selectGameSfxManager.Instance.playClick();
        factoryTutorialPanel.SetActive(true);
        animation_0[0].SetActive(true);
        animation_0[1].SetActive(true);
        RedImage.SetActive(false);
        animation_1.SetActive(false);
    }
    public void FactoryTutorialPanel_GamestartBtn()
    {
        selectGameSfxManager.Instance.playClick();
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }
    public void FactoryTutorialPanel_Close()
    {
        selectGameSfxManager.Instance.playBack();
        factoryTutorialPanel.SetActive(false);
    }
    public void FactoryTutorialPanel_nextBtn()
    {
        selectGameSfxManager.Instance.playNext();
        Factory_nextBtn.interactable = false;
        Factory_prevBtn.interactable = true;
        RedImage.SetActive(true);
        animation_0[0].SetActive(false);
        animation_0[1].SetActive(false);
        animation_1.SetActive(true);

    }
    public void FactoryTutorialPanel_PrevBtn()
    {
        selectGameSfxManager.Instance.playNext();
        Factory_nextBtn.interactable = true;
        Factory_prevBtn.interactable = false;
        animation_0[0].SetActive(true);
        animation_0[1].SetActive(true);
        RedImage.SetActive(false);
        animation_1.SetActive(false);
    }
}
