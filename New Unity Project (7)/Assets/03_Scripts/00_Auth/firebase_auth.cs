using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using Firebase.Unity.Editor;
using UnityEngine;
using UnityEngine.UI;

public class firebase_auth : MonoBehaviour
{
    /** auth 용 instance */
    FirebaseAuth auth;
    /** 사용자 */
    FirebaseUser user;

    string displayName;
    string emailAddress;

    /** 상태 출력용 */
    public Text txtPrint;

    void Start()
    {
        // 초기화
        Debug.Log("Hi");
        InitializeFirebase();
    }

    void InitializeFirebase() {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
    }

    /** 상태변화 추적 */
    void AuthStateChanged(object sender, System.EventArgs eventArgs) {
        if (auth.CurrentUser != user) {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null) {
                Debug.LogFormat("Signed out {0}", user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn) {
                Log(string.Format("Signed in {0}", user.UserId));
                displayName = user.DisplayName ?? "";
                emailAddress = user.Email ?? "";
                Log(string.Format("Signed in {0} _ {1}", displayName, emailAddress));
            }
        }
    }

    /** 익명 로그인 요청 */
    public void anoymousLogin() {
        auth
            .SignInAnonymouslyAsync()
            .ContinueWith(task => {
                if (task.IsCanceled) {
                    Debug.LogError("SignInAnonymouslyAsync was canceled.");
                    return;
                }
                if (task.IsFaulted) {
                    Debug.LogError("SignInAnonymouslyAsync encountered an error: " + task.Exception);
                    return;
                }

                user = task.Result;
                Log(string.Format("User signed in successfully: {0} ({1})",
                    user.DisplayName, user.UserId));
            });
    }

    void Log(string logText)
    {
        txtPrint.text += (logText + "\n");
        Debug.Log(logText);
    }
}
