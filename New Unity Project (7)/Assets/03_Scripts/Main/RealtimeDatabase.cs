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
}

class User {
    public string nickname;
    public string email;
    
    public int score_cashier;
    public int score_cinema;
    public int score_factory;
    
    public int money;
    
    public User(string nickname, string email) {
        this.nickname = nickname;
        this.email = email;
        
        score_cashier = 0;
        score_cinema = 0;
        score_factory = 0;
        money = 0;
    }
}
