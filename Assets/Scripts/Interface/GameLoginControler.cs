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
    public GameObject loading;
    public GameObject warning1, warning2, warning3, warning4;

    public void Awake()
    {
        if (LoginController == null)
        {
            transform.parent = null;
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
        public bool isAdmin = true;
    }

    [System.Serializable]
    class SignInAnwer
    {
        public string type;
        public string token;
        public string refreshToken;
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


        using (UnityWebRequest www = UnityWebRequest.Post("http://94.241.169.172:8081/api/account/signup", jsonData, "application/json"))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                warning1.SetActive(false);
                warning2.SetActive(false);
                warning3.SetActive(true);
                warning4.SetActive(false);
            }
            else
            {
                warning1.SetActive(false);
                warning2.SetActive(true);
                warning3.SetActive(false);
                warning4.SetActive(false);
                www.Dispose();
            }
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

        using (UnityWebRequest www = UnityWebRequest.Post("http://94.241.169.172:8081/api/account/signin", jsonData, "application/json"))
        {
            warning1.SetActive(true);
            warning2.SetActive(false);
            warning3.SetActive(false);
            warning4.SetActive(false);
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                warning1.SetActive(false);
                warning2.SetActive(false);
                warning3.SetActive(false);
                warning4.SetActive(true);
            }
            else
            {
                SignInAnwer answer = JsonUtility.FromJson<SignInAnwer>(www.downloadHandler.text);
                Progress.Instance.accessToken = answer.token;
                Progress.Instance.refreshToken = answer.refreshToken;
                StartCoroutine(Progress.Instance.GetPlayerId());
                StartCoroutine(Loading());
                www.Dispose();
            }
        }
    }

    IEnumerator Loading()
    {
        warning1.SetActive(false);
        warning2.SetActive(false);
        warning3.SetActive(false);
        warning4.SetActive(false);
        usernameLine.SetActive(false);
        passwordLine.SetActive(false);
        signinComplete.SetActive(false);
        backButton.SetActive(false);
        loading.SetActive(true);
        yield return new WaitForSeconds(4);
        Progress.Instance.LoadStat();
        SceneManager.LoadScene(28);
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
    }

    public void SignIn()
    {
        StartCoroutine(SignInRequest());
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
        warning1.SetActive(false);
        warning2.SetActive(false);
        warning3.SetActive(false);
        warning4.SetActive(false);
    }
}
