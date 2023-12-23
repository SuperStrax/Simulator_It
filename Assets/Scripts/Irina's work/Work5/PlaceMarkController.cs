using UnityEngine;

public class PlaceMarkController : MonoBehaviour
{
    public GameObject[] states;
    GameObject element;
    public GameObject controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        element = collision.gameObject;
    }

    public void Change()
    {
        switch (element.name)
        {
            case "Birds":
                states[0].SetActive(true);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
            case "Administration":
                states[1].SetActive(true);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
            case "Leos":
                states[2].SetActive(true);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
            case "Monkeys":
                states[3].SetActive(true);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
            case "Rhino":
                states[4].SetActive(true);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
            case "Cafe":
                states[5].SetActive(true);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
            case "Entrance":
                states[6].SetActive(true);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
        }
        controller.GetComponent<MapComplete>().placeCount++;
    }
}
