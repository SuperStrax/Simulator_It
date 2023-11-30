using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject timeSkip;
    public Button button;

    private void Update()
    {
        if (dialogue.numberDialog == 3)
            timeSkip.SetActive(true);

        if (dialogue == null)
            button.enabled = true;
    }

    public void TimeSkipEnd()
    {
        Destroy(timeSkip);
    }

    public void Zoom()
    {
        SceneManager.LoadScene(13);
    }
}
