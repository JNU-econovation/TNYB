using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
    Image timerBar;
    int i = 0;
    public GameObject cam;
    public float maxTime = 60f;
    float timeLeft;
    int count;

    void Start()
    {
        count = 0;
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }
    void FixedUpdate()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
            if (timerBar.fillAmount < 0.2 && i == 0)
            {
                i += 1;
                StartCoroutine(Shake(cam));
            }
        }else
        {
            Time.timeScale = 0;
        }
        if (timeLeft <= 0)
        {
            if (count == 0)
            {
                count++;
                FactoryManager.Instance.SetSCoreDB(); //DB
            }
            FactoryManager.Instance.Finish();
            for(int i=0; i<8; i++)
            {
                FactoryManager.Instance.DeleteObj(i);
            }
        }
    }

    IEnumerator Shake(GameObject cam)
    {
        while (true) { 
        float t = 1f;
        Vector3 originV = cam.transform.position;
        while (t > 0f)
        {
            t -= 0.1f;
            cam.transform.position = originV + (Vector3)Random.insideUnitCircle * 0.1f* t;
            yield return null;
        }

        cam.transform.position = originV;
    }
    }

}
