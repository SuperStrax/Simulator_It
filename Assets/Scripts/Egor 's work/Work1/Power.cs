using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public GameObject dialogue;

   public void PowerPC()
    {
        gameObject.GetComponent<Image>().enabled = true;
        dialogue.SetActive(true);
    }
}
