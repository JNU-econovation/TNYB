using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClicked : MonoBehaviour {
    public Text text;
    
	public void ButtonClick()
    {
        FactoryManager.Instance.ItemDestroy(int.Parse(text.text));
    }
   
}
