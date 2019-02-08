using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;

public class Login : MonoBehaviour
{
    private string SignInEmail;
    private string SignInPassword;
    
    private string SignUpEmail;
    private string SignUpPassword;
    private string SignUpConfirmedPassword;

    private string Nickname;

    public InputField SignInInputEmail;
    public InputField SignInInputPassword;
    
    public InputField SignUpInputEmail;
    public InputField SignUpInputPassword;
    public InputField SignUpInputConfirmedPassword;

    public InputField InputNickname;

    public Text NickWarningText;
    public GameObject NicknameOK;

    private const string warn_blank = "공백없이 입력해주세요";
    private const string warn_duplication = "이미 사용하고 있는 닉네임입니다";
    private const string warn_length_long = "닉네임이 너무 길어요";
    private const string warn_length_short = "닉네임이 너무 짧아요";

    private FirebaseAuth auth;
    public static FirebaseUser user;

    private void Awake()
    {
        //초기화
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    public void ClickSignUpBtn()
    {
        SfxManager.Instance.playClick();
        SignUpEmail = SignUpInputEmail.text;
        SignUpPassword = SignUpInputPassword.text;
        SignUpConfirmedPassword = SignUpInputConfirmedPassword.text;

        if (SignUpPassword == null || SignUpPassword == "")
        {
            SfxManager.Instance.playWrong();
            return;
        }
        
        if (SignUpPassword == SignUpConfirmedPassword)
        {
            Debug.Log("email: " + SignUpEmail + ", password: " + SignUpPassword);
            CreateUser();
        }
        else
        {
            SfxManager.Instance.playWrong();
            // 비밀번호가 다릅니다.
        }
    }

    private void CreateUser()
    {
        auth.CreateUserWithEmailAndPasswordAsync(SignUpEmail, SignUpPassword).ContinueWith(task =>
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
            Debug.LogFormat("Firebase user created successfully - DisplayName:({0}), UserId:({1})", newUser.DisplayName, newUser.UserId);
            MainManager.Instance.toSignInPanel();
        });
    }

    public void ClickSignInBtn()
    {
        SignInEmail = SignInInputEmail.text;
        SignInPassword = SignInInputPassword.text;
        
        Debug.Log("Sign In - email: " + SignInEmail + ", password: " + SignInPassword);
 
        LoginUser();
    }

    private void LoginUser()
    {
        auth.SignInWithEmailAndPasswordAsync(SignInEmail, SignInPassword).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                SfxManager.Instance.playWrong();
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                SfxManager.Instance.playWrong();
                return;
            }
 
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully - DisplayName:({0}), UserId:({1})",
                newUser.DisplayName, newUser.UserId);
            user = newUser;
            
            RealtimeDatabase.Instance.checkNicknameExistence();
        });
    }
    
    public void ClickStartOnNicknamePanel()
    {
        // 검사하는데 이것도 firebase는 callback이므로 여기에서 이렇게 검사하면 안된다.
        // 닉네임 공백 제거 할 것
        
        Nickname = InputNickname.text;
        Debug.Log("Nickname Input : "+InputNickname.text);
        Debug.Log("Nickname Input Length : "+InputNickname.text.Length);
        Debug.Log("Nickname no blank : "+InputNickname.text.Replace(" ", ""));
        Debug.Log("Nickname no blank Length: "+InputNickname.text.Replace(" ", "").Length);
        
        if (InputNickname.text.Length > InputNickname.text.Replace(" ", "").Length)
        {
            // 공백 존재
            SfxManager.Instance.playWrong();
            NickWarningText.text = warn_blank;
            return;
        };

        if (InputNickname.text.Length > 8)
        {
            // 길이 초과
            SfxManager.Instance.playWrong();
            NickWarningText.text = warn_length_long;
            return;
        }
        
        if (InputNickname.text.Length < 2)
        {
            // 길이 미만
            SfxManager.Instance.playWrong();
            NickWarningText.text = warn_length_short;
            return;
        }
        
        NickWarningText.GetComponent<Text>().enabled = false;
        NicknameOK.SetActive(true);

        /*
        if (!RealtimeDatabase.Instance.isDuplication(Nickname))
        {
            RealtimeDatabase.Instance.setNickname(Nickname);
            Debug.LogFormat("User nickname set successfully - DisplayName:({0})",
                user.DisplayName);
            MainManager.Instance.toMainPanel();
        }
        */
    }
    
    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
            }
        }
    }
}
