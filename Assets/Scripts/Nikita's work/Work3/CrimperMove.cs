using UnityEngine;
using UnityEngine.UI;

public class CrimperMove : MonoBehaviour
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
        if (dialogue == null && !ending.activeInHierarchy)
        rb.MovePosition(GetMousePosition());
    }

    private void OnMouseUp()
    {
        this.transform.position = startPosition;
        if (line != null && line.GetComponent<LineController>().crimperContact)
        {
            line.GetComponent<Image>().overrideSprite = line.GetComponent<LineController>().bareLine;
            line.GetComponent<LineController>().bare = true;
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
