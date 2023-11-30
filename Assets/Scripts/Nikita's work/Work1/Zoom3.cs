using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Zoom3 : MonoBehaviour
{
    public GameObject dialogue;

    public void Click()
    {
        SceneManager.LoadScene(16);
    }

    private void Update()
    {
        if (dialogue == null)
            this.GetComponent<Button>().enabled = true;
    }
}
