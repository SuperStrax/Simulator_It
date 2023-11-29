using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Zoom2 : MonoBehaviour
{
   public void Click()
    {
        SceneManager.LoadScene(5);
    }

    public Button button1;
    public Dialogue dialogue;

    public void Update()
    {
        if (dialogue == null) button1.enabled = true; 
    }
}
