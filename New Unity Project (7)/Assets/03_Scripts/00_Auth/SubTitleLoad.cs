using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubTitleLoad : MonoBehaviour
{
    private bool canGoUp = true;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        switch (Application.loadedLevel)
        {
            
            case 1:
                // up
                if (canGoUp)
                    StartCoroutine(IeTitleGoUp());
                break;
            case 2:    
            case 3:
            case 4:
                Destroy(gameObject);
                break;
            default:
                return;
        }
    }

    private IEnumerator IeTitleGoUp()
    {
        yield return null;
        for(int i =0; i < 12; i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(Vector3.up * Time.deltaTime * 0.3f);	
        }
        canGoUp = false;
    }
}
