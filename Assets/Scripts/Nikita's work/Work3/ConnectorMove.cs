using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectorMove : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 startPosition;
    GameObject line;
    public GameObject dialogue;
    public GameObject ending;


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
        if (dialogue == null &&  !ending.activeInHierarchy)
        rb.MovePosition(GetMousePosition());
    }

    private void OnMouseUp()
    {
        this.transform.position = startPosition;
        if (line != null && line.GetComponent<LineController>().connectorContact && line.GetComponent<LineController>().bare)
        {
            line.GetComponent<LineController>().lineWithConnector.SetActive(true);
            line.GetComponent<LineController>().button.SetActive(true);
            Destroy(line);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Line")
            line = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        line = null;
    }
}
