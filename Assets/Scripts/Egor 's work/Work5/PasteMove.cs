using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasteMove : MonoBehaviour
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
        if (controller.pastaContact)
        {
            processor.GetComponent<Image>().overrideSprite = controller.processorWithPasta;
            Destroy(gameObject);
            controller.processorSmeared = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == processor && controller.processorCleared)
            controller.pastaContact = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        controller.pastaContact = false;
    }
}
