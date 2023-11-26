using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupDriver : MonoBehaviour
{
    public GameObject setupWindow;
    public GameObject errorWindow;
    public GameObject dialogue;
    public GameObject backButton;

    public void Setup()
    {
        setupWindow.SetActive(true);
        dialogue.SetActive(true);
        backButton.SetActive(false);
    }

    public void Error()
    {
        errorWindow.SetActive(true);
        this.gameObject.SetActive(false);
        backButton.SetActive(false);
    }

    public void closeError()
    {
        errorWindow.SetActive(false);
        backButton.SetActive(true);
    }
}
