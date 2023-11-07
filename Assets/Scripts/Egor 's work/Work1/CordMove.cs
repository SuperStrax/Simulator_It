using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CordMove : MonoBehaviour
{
    Rigidbody2D rb;
    SocketChoose socket;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    private Vector2 GetMousePosition()
    {
        Vector2 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePosition.y = this.transform.position.y;
        return _mousePosition;
    }

    private void OnMouseDrag()
    {
        if(GetMousePosition().x > -7 && GetMousePosition().x < 3)
        rb.MovePosition(GetMousePosition());
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        socket = other.GetComponent<SocketChoose>();
    }

    private void OnMouseUp()
    {
        if (socket != null && socket.chosen)
            if (socket.name == "Socket 1")
                SceneManager.LoadScene(2);
            else if (socket.name == "Socket 2")
                SceneManager.LoadScene(3);
    }
}
