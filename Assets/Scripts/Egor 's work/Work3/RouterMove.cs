using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RouterMove : MonoBehaviour
{
    Rigidbody2D rb;
    public bool chosen;
    public BreakRouterController breakRouter;
    public Dialogue warning;
    public GameObject dialogue;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void WarningReset()
    {
        warning.numberDialog = 0;
        warning.gameObject.SetActive(false);
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
        if (breakRouter.selected && !breakRouter.GetComponent<Image>().enabled)
        {
            if (chosen) SceneManager.LoadScene(7);
            else warning.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
       if (dialogue == null) this.GetComponent<BoxCollider2D>().enabled = true; 
    }
}
