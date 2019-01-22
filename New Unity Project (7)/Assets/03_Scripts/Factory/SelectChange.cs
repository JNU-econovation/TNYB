using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectChange : MonoBehaviour {
    public Image images;
    public Image[] changeImages = new Image[4];

    public void Change()
    {
        switch (FactoryManager.Instance.getSelect())
        {
            case "pet":
                images = changeImages[0];
                break;
            case "can":
                images = changeImages[1];
                break;
            case "paper":
                images = changeImages[2];
                break;
            case "bottle":
                images = changeImages[3];
                break;

        }
    }
}
