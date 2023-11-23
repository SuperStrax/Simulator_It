using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Zoom3 : MonoBehaviour
{
    public GameObject dialogue;

    public void Click()
    {
        SceneManager.LoadScene(13);
    }

    private void Update()
    {
        if (dialogue == null)
            this.GetComponent<Button>().enabled = true;
    }
}
