using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CartridgeMove : MonoBehaviour
{
    Rigidbody2D rb;
    public bool chosen;
    public GameObject printer;
    public Dialogue dialogue;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
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
        if (this.chosen)
        {
            if (printer.GetComponent<CartridgeInsert>().selected)
            {
                printer.GetComponent<Image>().sprite = printer.GetComponent<CartridgeInsert>().broken;
                dialogue.numberDialog = 1;
                printer.GetComponent<CartridgeInsert>().cartridgeDelete();
                dialogue.gameObject.SetActive(true);
            }
        }
        else if (!this.chosen)
        {
            if (printer.GetComponent<CartridgeInsert>().selected)
            {
                dialogue.numberDialog = 0;
                printer.GetComponent<CartridgeInsert>().cartridgeDelete();
                dialogue.gameObject.SetActive(true);
            }
        }

    }
}
