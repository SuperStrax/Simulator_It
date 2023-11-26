using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrinterProblemController : MonoBehaviour
{
    public GameObject dialogue;
    public Button printerButton;
    public Button monitorButton;
    static bool changeScene;

    public void PrinterZoom()
    {
        SceneManager.LoadScene(16);
        changeScene = true;
    }

    public void MonitorZoom()
    {
        SceneManager.LoadScene(17);
        changeScene = true;
    }

    private void Update()
    {
       if (changeScene) Destroy(dialogue);
       if (dialogue == null)
        {
            printerButton.enabled = true;
            monitorButton.enabled = true;
        }
    }
}
