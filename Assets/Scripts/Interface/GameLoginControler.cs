using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameLoginControler : MonoBehaviour
{
    public static GameLoginControler LoginController;

    public GameObject signinButton;
    public GameObject signupButton;
    public GameObject backButton;
    public GameObject usernameLine;
    public GameObject passwordLine;
    public GameObject signupComplete;
    public GameObject signinComplete;
    public string accessToken;
    public string username;
    string password;

    public void Awake()
    {
        if (LoginController == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            LoginController = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    class SignInData
    {
        public string username;
        public string password;
    }

    class SignUpData
    {
        public string username;
        public string password;
        public string gender = "male";
        public string isAdmin = "false";
    }


    IEnumerator SignUpRequest()
    {
        string jsonData;
        username = usernameLine.GetComponent<TMP_InputField>().text;
        password = passwordLine.GetComponent<TMP_InputField>().text;

  
        SignUpData signUpData = new SignUpData();
        signUpData.username = username;
        signUpData.password = password;
        jsonData = JsonUtility.ToJson(signUpData);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8081/api/account/signup", jsonData, "application/json"))
        {
            yield return www.SendWebRequest();
            www.Dispose();
        }
    }

    IEnumerator SignInRequest()
    {
        string jsonData;
        username = usernameLine.GetComponent<TMP_InputField>().text;
        password = passwordLine.GetComponent<TMP_InputField>().text;
        WWWForm form = new WWWForm();
        SignInData signInData = new SignInData();
        signInData.username = username;
        signInData.password = password;
        jsonData = JsonUtility.ToJson(signInData);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8081/api/account/signin", jsonData, "application/json"))
        {
            yield return www.SendWebRequest();
            int tokenIndex1 = www.downloadHandler.text.LastIndexOf("token");
            int tokenIndex2 = www.downloadHandler.text.LastIndexOf("refreshToken");
            accessToken = www.downloadHandler.text.Substring(tokenIndex1 + 8, tokenIndex2 - 29);
            www.Dispose();
        }
    }

    public void SignUpClick()
    {
        signinButton.SetActive(false);
        signupButton.SetActive(false);
        backButton.SetActive(true);
        usernameLine.SetActive(true);
        passwordLine.SetActive(true);
        signupComplete.SetActive(true);
    }

    public void SignInClick()
    {
        signinButton.SetActive(false);
        signupButton.SetActive(false);
        backButton.SetActive(true);
        usernameLine.SetActive(true);
        passwordLine.SetActive(true);
        signinComplete.SetActive(true);
    }

    public void SignUp()
    {
        StartCoroutine(SignUpRequest());
        SignUpRequest();
        SceneManager.LoadScene(28);
    }

    public void SignIn()
    {
        StartCoroutine(SignInRequest());
        SignInRequest();
        SceneManager.LoadScene(28);
    }

    public void Back()
    {
        signinButton.SetActive(true);
        signupButton.SetActive(true);
        backButton.SetActive(false);
        usernameLine.GetComponent<TMP_InputField>().text = "";
        usernameLine.SetActive(false);
        passwordLine.GetComponent<TMP_InputField>().text = "";
        passwordLine.SetActive(false);
        signupComplete.SetActive(false);
        signinComplete.SetActive(false);

    }
}
