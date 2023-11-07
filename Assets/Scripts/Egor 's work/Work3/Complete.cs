using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Complete : MonoBehaviour
{
    public GameObject completed;
    public Dialogue dialogue;
    public void Click()
     {
        completed.gameObject.SetActive(true);
        dialogue.gameObject.SetActive(true);
     }
}
