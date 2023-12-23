using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddressRepairController : MonoBehaviour
{
    public GameObject[] states;
    GameObject element;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        element = collision.gameObject;
    }

    public void Change()
    {
        switch (element.name)
        {
            case "list.pdf":
                states[0].SetActive(true);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
            case "css":
                states[1].SetActive(true);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
            case "http":
                states[2].SetActive(true);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
            case "exam.ru":
                states[3].SetActive(true);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
            case "www":
                states[4].SetActive(true);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
        }
    }
}
