using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CableProblemController : MonoBehaviour
{
    public GameObject monitorCable;
    public GameObject keyboardCable;
    public GameObject mouseCable;
    public GameObject soundCable;
    public GameObject connectedCable;
    public GameObject connectedCable2;

    public bool monitorCableCheck;
    public bool keyboardCableCheck;
    public bool mouseCableCheck;
    public bool soundCableCheck;

    public bool match;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.GetComponent<Image>().color = new Color32(0, 0, 0, 180);
        if (collision.gameObject == monitorCable && monitorCableCheck)
            match = true;
        else if (collision.gameObject == keyboardCable && keyboardCableCheck)
            match = true;
        else if(collision.gameObject == mouseCable && mouseCableCheck)
            match = true;
        else if(collision.gameObject == soundCable && soundCableCheck)
            match = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        match = false;
    }
}
