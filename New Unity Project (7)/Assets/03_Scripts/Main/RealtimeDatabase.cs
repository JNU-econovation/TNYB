using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Unity.Editor;
using Firebase.Database;
using Firebase;

public class RealtimeDatabase : MonoBehaviour
{
    private FirebaseApp firebaseApp;
    private DatabaseReference databaseReference;
    
    private static RealtimeDatabase instance;

    public static RealtimeDatabase Instance
    {
        get { return instance; }
    }
    
    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        instance = this;
        
        firebaseApp = FirebaseDatabase.DefaultInstance.App;
        firebaseApp.SetEditorDatabaseUrl("https://ddak-8f8b5.firebaseio.com/");
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.DefaultInstance.SetEditorP12FileName("ddak-8f8b5-7e0bc8521a04.p12");
        
        // 아래 비밀번호에는 특별하게 설정한거 없으면 notasecret 일 겁니다.
        FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");
    }

    public void InitDatabase()
    {
        if (Login.user != null)
        {
//            Debug.LogFormat("Write user - DisplayName:({0}), UserId:({1}), UserEmail:({2})",
//                Login.user.DisplayName, Login.user.UserId, Login.user.Email);
            WriteNewUser(Login.user.UserId, Login.user.DisplayName, Login.user.Email);   
        }
    }
    
    private void WriteNewUser(string uid, string nickname, string email)
    {
        User user = new User(nickname, email);
        string json = JsonUtility.ToJson(user);
        databaseReference.Child("users").Child(uid).SetRawJsonValueAsync(json);
    }

    public void setNickname(string nickname)
    {
        databaseReference.Child("users").Child(Login.user.UserId).Child("nickname").SetValueAsync(nickname);        
    }

    public void checkNicknameExistence()
    {
        FirebaseDatabase.DefaultInstance.GetReference("users")
            .GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {

                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    if (snapshot.Child(Login.user.UserId).Child("nickname").Value == null || snapshot.Child(Login.user.UserId).Child("nickname").Value == "")
                    {
                        InitDatabase();
                        MainManager.Instance.toNicknamePanel();
                        return;
                    }
                    MainManager.Instance.toMainPanel();
                }
            });
    }

    public void checkNicknameDuplication(string nickname)
    {   
        FirebaseDatabase.DefaultInstance
            .GetReference("users") // 읽어올 데이터 이름
            .GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    
                    // DataSnapshot 타입에 저장된 값 불러오기
                    foreach (var item in snapshot.Children)
                    {
                        // Debug.Log("value : " + item.Child("nickname").Value);
                        if (nickname == (string) item.Child("nickname").Value)
                        {
                            // 중복 감지
                            Login.Instance.handleNicknameDuplication();
                        }
                    }                    
                    // Debug.Log("1");
                    if (!Login.Instance.getIsDuplicate())
                    {
                        // Debug.Log("2");
                        Login.Instance.NicknameComplete(nickname);
                    }
                    
                }
            });
    }

    public void SetMyRoomData(string str, bool[] array)
    {
        for(int i=0; i<array.Length; i++)
         databaseReference.Child("users").Child(Login.user.UserId).Child(str).Child(i.ToString()).SetValueAsync(array[i]);
    }

}
class User {
    public string nickname;
    public string email;
    
    public int score_cashier;
    public int score_cinema;
    public int score_factory;
    
    public int money;

    public bool[] tile_bool = new bool[4]; // 0: yellow, 1: green, 2: blue, 3: gray
    public bool[] bed_bool = new bool[3]; // 0: red, 1: blue, 2: purple
    public bool[] table_bool = new bool[5]; //0: pc-table_gray 1: pc-table_blue 2: pc-table_red 3: table_2 4: tv-table;
    public bool[] sofa_bool = new bool[6]; // 0: sofa_red, 1:sofa_blue 2: sofa_green 3: sofa2_red, 4: sofa2_blue, 5: sofa2_green;
    public bool[] chair_bool = new bool[3]; //0: chair_gray, 1: chair_red, 2:chair_blue
    public bool[] picture_bool = new bool[3];//0: picture_yellow, 1:picture_red, 2:picture_blue
    public bool[] appliance_bool = new bool[3];//0: computer, 1:tv, 2:lamp
    public bool[] furniture_bool = new bool[2];
    public bool[] etc_bool = new bool[2]; //0:trashcan 1: rug

    public User(string nickname, string email) {
        this.nickname = nickname;
        this.email = email;
        
        score_cashier = 0;
        score_cinema = 0;
        score_factory = 0;
        money = 0;
    }
}

