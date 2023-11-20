using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CottonMove : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 startPosition;
    public GameObject spirt;
    public ProcessorRepairController controller;
    public bool smeared;
    public GameObject processor;
    public Sprite smearedCotton;

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
        if (controller.spirtContact)
        {
            this.GetComponent<Image>().overrideSprite = smearedCotton;
            Destroy(spirt);
            smeared = true;
        }

        if (controller.processorContact)
        {
            processor.GetComponent<Image>().overrideSprite = controller.clearProcessor;
            controller.processorCleared = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == spirt)
        {
            controller.spirtContact = true;
        }

        if (collision.gameObject == processor && smeared)
        {
           controller.processorContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        controller.spirtContact = false;
        controller.processorContact = false;
    }
}
