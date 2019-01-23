using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    void Start()
    {
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        StartCoroutine(IeScaleUp());
        StartCoroutine(IeScaleBeating());
    }

    private IEnumerator IeScaleUp()
    {
        yield return null;
        for(int i =0;i<70;i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
    }
    
    private IEnumerator IeScaleBeating()
    {
        yield return null;
        for(int i =0;i<5;i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
        
        for(int i =0;i<5;i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
        }
        
        for(int i =0;i<5;i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
