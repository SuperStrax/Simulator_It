using UnityEngine;
using UnityEngine.UI;

public class BlockMove : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 startPosition;
    public GameObject dialogue;
    public GameObject target;
    bool activated = false;
    public SiteRepairController controller;

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
        if (dialogue == null && controller.repairActivated)
        {
            rb.MovePosition(GetMousePosition());
            target.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnMouseUp()
    {
        if (activated)
        {
            Destroy(gameObject);
            target.GetComponent<Image>().enabled = true;
        }
        else
        {
            rb.MovePosition(startPosition);
        }
        target.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            activated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        activated = false;
    }
}
