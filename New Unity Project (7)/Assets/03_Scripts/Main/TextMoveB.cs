using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMoveB : MonoBehaviour
{
    public float speed;
    public float x = 0;
    public float y = 0;
    RectTransform RT;
    // Use this for initialization
    void Start()
    {
        RT = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        x -= speed;
        y -= speed;
        RT.localPosition = new Vector3(x, y, 0);
        if(x < -800)
        {
            x = 0;
            y = 0;
        }
    }
}
