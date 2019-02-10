using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_ciema : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject tuto1;
    public GameObject tuto2;
    public GameObject NextBtn;
    public GameObject PreBtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenTutorial()
    {
        tutorialPanel.SetActive(true);
        tuto1.SetActive(true);
        tuto2.SetActive(false);
    }
    public void NextTutorial()
    {
        tuto1.SetActive(false);
        tuto2.SetActive(true);
        NextBtn.SetActive(false);
        PreBtn.SetActive(true);
    }
    public void PrevTutorial()
    {
        tuto2.SetActive(false);
        tuto1.SetActive(true);
        NextBtn.SetActive(true);
        PreBtn.SetActive(false);
    }
    public void CloseTutorial()
    {
        tutorialPanel.SetActive(false);
        tuto1.SetActive(false);
        tuto2.SetActive(false);
    }
}
