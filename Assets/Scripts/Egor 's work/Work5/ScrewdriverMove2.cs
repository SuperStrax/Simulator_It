using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrewdriverMove2 : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 startPosition;
    GameObject pin;
    public int pinCount = 0;
    public ProcessorRepairController controller;

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
        if (pin != null && pin.tag == "Pin" && pin.GetComponent<Image>().enabled)
        {
            pin.GetComponent<Image>().enabled = false;
            pinCount++;
        }
        else if (pin != null && pin.tag == "Pin" && !pin.GetComponent<Image>().enabled && controller.radiator2 == null)
        {
            pin.GetComponent<Image>().enabled = true;
            pinCount--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pin = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pin = null;
    }
}
