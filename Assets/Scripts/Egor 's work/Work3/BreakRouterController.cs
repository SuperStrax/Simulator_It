using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BreakRouterController : MonoBehaviour
{
    public bool selected = false;

    public void Click()
    {
        this.GetComponent<Image>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        selected = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        selected = false;
    }
}
