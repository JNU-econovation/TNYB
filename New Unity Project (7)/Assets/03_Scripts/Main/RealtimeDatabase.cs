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
    
    // Start is called before the first frame update
    void Awake()
    {
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
            WriteNewUser(Login.user.UserId, Login.user.DisplayName, Login.user.Email);   
        }
    }
    
    private void WriteNewUser(string uid, string name, string email)
    {
        User user = new User(name, email);
        string json = JsonUtility.ToJson(user);
        databaseReference.Child("users").Child(uid).SetRawJsonValueAsync(json);
    }
}
