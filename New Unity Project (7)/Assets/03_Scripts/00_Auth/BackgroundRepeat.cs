using UnityEngine;
using System.Collections;

public class BackgroundRepeat : MonoBehaviour {
    public float scrollSpeed = 1.2f; 
    //스크롤할 속도를 상수로 지정해 줍니다.
    private Material thisMaterial;
    //Quad의 Material 데이터를 받아올 객체를 선언합니다.
    void Start () {
        //객체가 생성될때 최초 1회만 호출 되는 함수 입니다.
        thisMaterial = GetComponent<Renderer>().material; 
        //현재 객체의 Component들을 참조해 Renderer라는 컴포넌트의 Material정보를 받아옵니다.
    }

    void Update () {
        Vector2 newOffset = thisMaterial.mainTextureOffset;
        // 새롭게 지정해줄 OffSet 객체를 선언합니다.
        newOffset.Set(newOffset.x + (scrollSpeed * Time.deltaTime), 0);
        // Y부분에 현재 y값에 속도에 프레임 보정을 해서 더해줍니다.
        thisMaterial.mainTextureOffset = newOffset;
        //그리고 최종적으로 Offset값을 지정해줍니다.
    }
}
