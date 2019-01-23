using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause : MonoBehaviour {
    public GameObject BlockPanel; // 가림막
    bool isPaused = true;
 

        public void pauseGame()
        {
            Time.timeScale = 0;
            isPaused = true;
            BlockPanel.SetActive(true);

        }
        public void ResumeGame()
        {
            Time.timeScale = 1;
            isPaused = false;
            BlockPanel.SetActive(false);
        }
}
