using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase.Database;
using Firebase;
using Firebase.Unity.Editor;

public class firebaseInit : MonoBehaviour
{
    private const string email = "econo_ddak@econovation.kr";
    private const string password = "ecnv2018";
    public Text loginResult;
    public InputField nicknameInput;
    
    private string userNickname;
    private bool hasNickname = false;
    
    FirebaseAuth auth;
    FirebaseUser AdminUser;
    
    FirebaseApp firebaseApp;
    DatabaseReference databaseReference;
    
    void Awake()
    {
        // 해상도
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(Screen.width, Screen.width * 9/16, true);
        
        // 초기화
        auth = FirebaseAuth.DefaultInstance;
        
        // firebase database
        firebaseApp = FirebaseDatabase.DefaultInstance.App;
        firebaseApp.SetEditorDatabaseUrl("https://ddak-8f8b5.firebaseio.com/");
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.DefaultInstance.SetEditorP12FileName("ddak-8f8b5-7e0bc8521a04.p12");
        
        // 비밀번호 특별하게 설정한거 없으면 notasecret
        FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        LoginAdminAccount();
        InitializeFirebase();
        InitializePlayerPrefs();
    }

    private void InitializePlayerPrefs()
    {
        if (PlayerPrefs.GetString("Nickname", null) == null)
        {
            // 가져올 닉네임이 없다
            // need new nickname
        }
        else
        {
            // 닉네임이 있다.
            hasNickname = true;
        }
        
    }
    
    IEnumerator checkNickname()
    {
        yield return null;
        string tempNick = nicknameInput.text;
        
        // database에서 nickname 검사
        
    }

    private void LoginAdminAccount()
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                loginResult.text = "로그인 실패";                
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                loginResult.text = "로그인 실패";               
                return;
            }

        });
    }
    
    void InitializeFirebase() {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
    }

    /** 상태변화 추적 */
    void AuthStateChanged(object sender, System.EventArgs eventArgs) {
        if (auth.CurrentUser != AdminUser) {
            bool signedIn = AdminUser != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && AdminUser != null) {
                Debug.LogFormat("Signed out {0}", AdminUser.UserId);
            }
            AdminUser = auth.CurrentUser;
            if (signedIn) {
                Log(string.Format("Signed in {0}", AdminUser.UserId));
                string displayName = AdminUser.DisplayName ?? "";
                string emailAddress = AdminUser.Email ?? "";
                Log(string.Format("Signed in {0} _ {1}", displayName, emailAddress));
            }
        }
    }
    
    void Log(string logText)
    {
        loginResult.text += (logText + "\n");
        Debug.Log(logText);
    }
}
