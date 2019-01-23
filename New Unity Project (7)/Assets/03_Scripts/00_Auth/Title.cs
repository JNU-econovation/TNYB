using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    void Start()
    {
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
//        StartCoroutine(IeScaleUp());
    }

    private IEnumerator IeScaleUp()
    {
        float scaleValue = 0.01f;
        float MaxscaleValue = 0.7f;
        
        yield return null;
        for(int i =0;i<14;i++)
        {
            yield return new WaitForSeconds(0.03f);
            transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
        }
        StartCoroutine(IeScaleBeatingUp());
    }
    
    private IEnumerator IeScaleBeatingUp()
    {
        yield return null;
        for(int i =0;i<10;i++)
        {
            yield return new WaitForSeconds(0.1f);
            transform.localScale += new Vector3(0.005f, 0.005f, 0.005f);
        }
        StartCoroutine(IeScaleBeatingDown());
    }
    
    private IEnumerator IeScaleBeatingDown()
    {
        yield return null;
        for(int i =0;i<10;i++)
        {
            yield return new WaitForSeconds(0.1f);
            transform.localScale -= new Vector3(0.005f, 0.005f, 0.005f);
        }
        StartCoroutine(IeScaleBeatingUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
