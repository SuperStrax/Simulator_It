using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CableMove : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 startPosition;
    public CableProblemController usbPort;
    public CableProblemController jackPort;
    public CableProblemController hdmiPort;
    public GameObject warning;
    bool connectTry;
    public CompleteCheck completeCheck;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    private Vector2 GetMousePosition()
    {
        Vector2 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return _mousePosition;
    }

    private void OnMouseDrag()
    {
        rb.MovePosition(GetMousePosition());
    }

    private void OnMouseUp()
    {
        this.transform.position = startPosition;
        if (usbPort.match)
        {
            if(this.name == "Keyboard Cable")
            {
            usbPort.connectedCable.SetActive(true);
            this.gameObject.SetActive(false);
            completeCheck.connectCount++;
            }
            else if (this.name == "Mouse Cable")
            {
                usbPort.connectedCable2.SetActive(true);
                this.gameObject.SetActive(false);
                completeCheck.connectCount++;
            }
        }
        else if(jackPort.match)
        {
            jackPort.connectedCable.SetActive(true);
            this.gameObject.SetActive(false);
            completeCheck.connectCount++;
        }
        else if(hdmiPort.match)
        {
            hdmiPort.connectedCable.SetActive(true);
            this.gameObject.SetActive(false);
            completeCheck.connectCount++;
        }
        else
        {
            if(connectTry)
            warning.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "USB Port" || collision.gameObject.name == "HDMI Port" || collision.gameObject.name == "Jack Port")
            connectTry = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        connectTry = false;
    }
}
