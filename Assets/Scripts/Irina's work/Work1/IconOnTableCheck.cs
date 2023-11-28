using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconOnTableCheck : MonoBehaviour
{
    public GameObject iconOnTable;

    private void OnTriggerExit2D(Collider2D collision)
    {
        iconOnTable.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        iconOnTable.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
    }
}
