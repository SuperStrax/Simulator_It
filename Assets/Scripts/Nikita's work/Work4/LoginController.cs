using TMPro;
using UnityEngine;

public class LoginController : MonoBehaviour
{
    public GameObject login;
    public GameObject password;
    public GameObject dialogue;
    public string correctLogin;
    public string correctPassword;

    public void Lol()
    {
        if (dialogue == null)
        {
            if (login.GetComponent<TMP_InputField>().text == correctLogin && password.GetComponent<TMP_InputField>().text == correctPassword)
                Destroy(gameObject);
        }
    }
}
