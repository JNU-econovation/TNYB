using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;

public class firebaseInit : MonoBehaviour
{
    private const string email = "econo_ddak@econovation.kr";
    private const string password = "ecnv2018";
    public Text loginResult;
    
    FirebaseAuth auth;
    FirebaseUser AdminUser;
    
    void Awake()
    {
        // 해상도
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
//        Screen.SetResolution(1080, 1920, true);
        Screen.SetResolution(Screen.width, Screen.width * 1080/1920, true);
        
        
        // 초기화
        auth = FirebaseAuth.DefaultInstance;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        LoginAdminAccount();
        InitializeFirebase();
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
