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
    void Awake()
    {
        // 초기화
        auth = FirebaseAuth.DefaultInstance;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        LoginAdminAccount();
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
 
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            loginResult.text = newUser.DisplayName;

        });
    }
}
