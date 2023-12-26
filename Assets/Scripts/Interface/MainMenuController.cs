using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI welcome;
    string playerName = "UnnamedPlayer";

    public void Awake()
    {
        playerName = GameLoginControler.LoginController.username;
        welcome.text = "Здравствуй, " + playerName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    


}
