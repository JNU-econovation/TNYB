using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;

public class Login : MonoBehaviour
{
    [SerializeField] private string email;
    [SerializeField] private string password;
    [SerializeField] private string confirmedPassword;
    [SerializeField] private GameObject mainManager;

    public InputField inputEmail;
    public InputField inputPassword;
    public InputField inputConfirmedPassword;

    private FirebaseAuth auth;

    private void Awake()
    {
        //초기화
        auth = FirebaseAuth.DefaultInstance;
    }

    public void ClickSignUpBtn()
    {
        SfxManager.Instance.playClick();
        email = inputEmail.text;
        password = inputPassword.text;
        confirmedPassword = inputConfirmedPassword.text;

        if (password == confirmedPassword)
        {
            Debug.Log("email: " + email + ", password: " + password);
            CreateUser();
        }
        else
        {
            SfxManager.Instance.playBack();
            // 비밀번호가 다릅니다.
        }
    }

    private void CreateUser()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }

            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase User has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
