using UnityEngine;

public class PointMove : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 startPosition;
    public GameObject dialogue;
    public GameObject place;

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

    private void OnMouseUp()
    {
        if (place.tag == "Place" && place != null)
        {
            Destroy(gameObject);
            place.GetComponent<PlaceMarkController>().Change();
        }
        else
        {
            rb.MovePosition(startPosition);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        place = collision.gameObject;
    }
}
