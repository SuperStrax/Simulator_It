using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void FullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
