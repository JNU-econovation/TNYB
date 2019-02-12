using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;

public class Login : MonoBehaviour
{
    public GameObject loginLoading;
    
    private string SignInEmail;
    private string SignInPassword;
    
    private string SignUpEmail;
    private string SignUpPassword;
    private string SignUpConfirmedPassword;

    public Text signUpErrorText;
    public GameObject signUpPanel;

    private string Nickname;

    public InputField SignInInputEmail;
    public InputField SignInInputPassword;
    
    public InputField SignUpInputEmail;
    public InputField SignUpInputPassword;
    public InputField SignUpInputConfirmedPassword;

    public InputField InputNickname;

    public Text NickWarningText;
    public GameObject NicknameOK;

    private string confirmedNickname;

    private const string warn_blank = "공백없이 입력해주세요";
    private const string warn_duplication = "이미 사용하고 있는 닉네임입니다";
    private const string warn_length_long = "닉네임이 너무 길어요";
    private const string warn_length_short = "닉네임이 너무 짧아요";

    private bool isDuplicate = false;

    private FirebaseAuth auth;
    public static FirebaseUser user;

    private string ID_Value;

    public static Login instance;

    public static Login Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        
        //초기화
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
        signUpPanel.SetActive(false);
    }

    public void Start()
    {
        if(PlayerPrefs.GetString("ID")!= null)
        {
            SignInInputEmail.text = PlayerPrefs.GetString("ID");
        }
        if (PlayerPrefs.GetString("password") != null)
            SignInInputPassword.text = PlayerPrefs.GetString("password");
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
            wrongPasswordForm();
            return;
        }
        
        if (SignUpPassword == SignUpConfirmedPassword)
        {
            Debug.Log("email: " + SignUpEmail + ", password: " + SignUpPassword);
            CreateUser();
            PlayerPrefs.SetString("ID", SignUpInputEmail.text); //기기에 아이디 저장
            PlayerPrefs.SetString("password", SignUpInputPassword.text);
            PlayerPrefs.Save();
        }
        else
        {
            SfxManager.Instance.playWrong();
            wrongPassword();
            // 비밀번호가 다릅니다.
        }
    }

    public void wrongPassword()
    {
        signUpPanel.SetActive(true);
        signUpErrorText.text = "비밀번호가 일치하지 않습니다";
    }
    
    public void wrongPasswordForm()
    {
        signUpPanel.SetActive(true);
        signUpErrorText.text = "비밀번호 형식이\n정상적이지 않습니다";
    }
    
    public void wrongTotal()
    {
        signUpPanel.SetActive(true);
        signUpErrorText.text = "이메일 중복 또는 형식 오류!\n혹은 비밀번호를 더 어렵게 해주세요";
    }

    public void doneSignUpError()
    {
        signUpPanel.SetActive(false);
    }

    private void CreateUser()
    {
        auth.CreateUserWithEmailAndPasswordAsync(SignUpEmail, SignUpPassword).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                wrongTotal();
                return;
            }

            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                wrongTotal();
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

        LoginLoadingStart();

        // Debug.Log("Sign In - email: " + SignInEmail + ", password: " + SignInPassword);
 
        LoginUser();
    }

    private void LoginUser()
    {
        auth.SignInWithEmailAndPasswordAsync(SignInEmail, SignInPassword).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                SfxManager.Instance.playWrong();
                LoginLoadingEnd();
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                SfxManager.Instance.playWrong();
                LoginLoadingEnd();
                return;
            }
 
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully - DisplayName:({0}), UserId:({1})",
                newUser.DisplayName, newUser.UserId);
            user = newUser;
            
            RealtimeDatabase.Instance.checkNicknameExistence();
        });
    }

    public void LoginLoadingStart()
    {
        loginLoading.SetActive(true);
    }
    
    public void LoginLoadingEnd()
    {
        loginLoading.SetActive(false);
    }
    
    public void ClickCheckOnNicknamePanel()
    {
        isDuplicate = false;
        Nickname = InputNickname.text;
        // 검사하는데 이것도 firebase는 callback이므로 여기에서 이렇게 검사하면 안된다.
        
        if (Nickname.Length > Nickname.Replace(" ", "").Length)
        {
            // 공백 존재
            SfxManager.Instance.playWrong();
            NickWarningText.text = warn_blank;
            NickWarningText.GetComponent<Text>().enabled = true;
            NicknameOK.SetActive(false);
            return;
        };

        if (Nickname.Length > 8)
        {
            // 길이 초과
            SfxManager.Instance.playWrong();
            NickWarningText.text = warn_length_long;
            NickWarningText.GetComponent<Text>().enabled = true;
            NicknameOK.SetActive(false);
            return;
        }
        
        if (Nickname.Length < 2)
        {
            // 길이 미만
            SfxManager.Instance.playWrong();
            NickWarningText.text = warn_length_short;
            NickWarningText.GetComponent<Text>().enabled = true;
            NicknameOK.SetActive(false);
            return;
        }

        RealtimeDatabase.Instance.checkNicknameDuplication(Nickname);
    }

    public void ClickStartButtonOnNicknamePanel()
    {
        if (confirmedNickname == Nickname)
        {
            RealtimeDatabase.Instance.setNickname(Nickname);
            MainManager.Instance.toMainPanel();
            return;
        }
        SfxManager.Instance.playWrong();
        NicknameOK.SetActive(false);
        NickWarningText.GetComponent<Text>().enabled = true;
        NickWarningText.text = "다시 검사하세요";
    }

    public void handleNicknameDuplication()
    {
        isDuplicate = true;
        SfxManager.Instance.playWrong();
        NickWarningText.text = warn_duplication;
        NickWarningText.GetComponent<Text>().enabled = true;
        NicknameOK.SetActive(false);
    }

    public void NicknameComplete(string nickname)
    {
        NickWarningText.GetComponent<Text>().enabled = false;
        NicknameOK.SetActive(true);
        SfxManager.Instance.playCheck();
        NicknameOK.SetActive(true);
        
        // 검증된 닉네임에 저장
        confirmedNickname = nickname;
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

    public bool getIsDuplicate()
    {
        return isDuplicate;
    }
}
