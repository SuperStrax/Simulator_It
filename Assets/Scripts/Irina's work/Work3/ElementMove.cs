using UnityEngine;

public class ElementMove : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 startPosition;
    public GameObject dialogue;
    public GameObject[] targets;
    bool match = false;
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
        if (match)
        {
            Destroy(gameObject);
            place.GetComponent<AddressRepairController>().Change();
        }
        else
        {
            rb.MovePosition(startPosition);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (GameObject target in targets)
        {
            if (target == collision.gameObject)
            {
                match = true;
                place = collision.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        match = false;
    }
}
