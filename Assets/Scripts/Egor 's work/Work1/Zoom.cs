using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
   public void Click()
    {
        SceneManager.LoadScene(3);
    }

    public Button button1;
    public Button button2;
    public Dialogue dialogue;

    public void Update()
    {
        if (dialogue == null)
        {
            button1.enabled = true;
            button2.enabled = true;
        }
    }
}
