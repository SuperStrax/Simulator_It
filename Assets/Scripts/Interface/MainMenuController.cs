using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI welcome;
    string playerName = "UnnamedPlayer";

    private void Start()
    {
        welcome.text = "����������, " + playerName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    


}
