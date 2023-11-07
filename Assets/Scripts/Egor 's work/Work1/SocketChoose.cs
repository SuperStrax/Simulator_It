using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SocketChoose : MonoBehaviour
{
    public bool chosen = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        this.GetComponent<Image>().color = Color.grey;
        chosen = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.GetComponent<Image>().color = Color.white;
        chosen = false;
    }

}
