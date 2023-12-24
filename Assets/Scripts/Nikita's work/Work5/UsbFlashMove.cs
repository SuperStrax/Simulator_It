using UnityEngine;

public class UsbFlashMove : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 startPosition;
    public GameObject dialogue;
    public GameObject target;
    bool connect = false;
    public GameObject connectedUsb;
    public GameObject bios;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        startPosition = this.transform.position;
    }

    private Vector2 GetMousePosition()
    {
        Vector2 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return _mousePosition;
    }

    private void OnMouseDrag()
    {
        if (dialogue == null)
        {
            rb.MovePosition(GetMousePosition());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
            connect = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        connect = false;
    }

    private void OnMouseUp()
    {
        if (connect)
        {
            connectedUsb.SetActive(true);
            bios.SetActive(true);
            Destroy(gameObject);
        }
        else
        {
            rb.MovePosition(startPosition);
        }
    }
}
