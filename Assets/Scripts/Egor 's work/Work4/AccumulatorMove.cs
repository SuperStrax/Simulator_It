using UnityEngine;
using UnityEngine.UI;

public class AccumulatorMove : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 startPosition;
    public GameObject dialogue;
    public GameObject accumulator;
    bool chosen = false;
    public RepairController repairController;

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
        if (dialogue == null)
            rb.MovePosition(GetMousePosition());
    }

    private void OnMouseUp()
    {
        if (chosen && !accumulator.GetComponent<Image>().enabled)
        {
            accumulator.GetComponent<Image>().enabled = true;
            Destroy(gameObject);
            repairController.accumulatorFix = true;
        }
        else
            this.transform.position = startPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == accumulator)
            chosen = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject != accumulator)
            chosen = false;
    }
}
