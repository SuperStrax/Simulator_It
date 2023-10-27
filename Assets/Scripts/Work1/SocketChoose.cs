using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SocketChoose : MonoBehaviour
{
    SpriteRenderer _renderer;
    public bool chosen = false;

    public void Start()
    {
        _renderer = this.GetComponent<SpriteRenderer>();  
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        _renderer.color = Color.grey;
        chosen = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _renderer.color = Color.white;
        chosen = false;
    }

}
