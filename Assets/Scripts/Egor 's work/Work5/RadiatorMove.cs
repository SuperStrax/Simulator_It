using UnityEngine;

public class RadiatorMove : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 startPosition;
    public GameObject processor;
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
        if (controller.radiatorContact)
        {
            controller.radiator.SetActive(true);
            controller.cap.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == processor && controller.processorSmeared)
            controller.radiatorContact = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        controller.radiatorContact = false;
    }
}
