using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonClicked : MonoBehaviour {
    
	public void ButtonClick()
    {
        int a = EventSystem.current.currentSelectedGameObject.name[0] - '0';
        FactoryManager.Instance.ItemDestroy(a);
    }
   
}
