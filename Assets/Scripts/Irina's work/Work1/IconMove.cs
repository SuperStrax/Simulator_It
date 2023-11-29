using UnityEngine;
using UnityEngine.UI;

public class IconMove : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 startPosition;
    public GameObject iconOnTable;
    bool onTable;
    public GameObject dialogue;

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
            if (GetMousePosition().x > -3.9 && GetMousePosition().x < 5.5 && GetMousePosition().y < 3.9 && GetMousePosition().y > -0.6)
            {
                rb.MovePosition(GetMousePosition());
                if ((GetMousePosition().x > -2.4 && GetMousePosition().x < 3.8) && (GetMousePosition().y < 3.6 && GetMousePosition().y > 0))
                {
                    iconOnTable.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                    onTable = false;
                }

                else
                {
                    iconOnTable.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
                    onTable = true;
                }
            }
        }
    }

    private void OnMouseUp()
    {
        if (onTable)
        {
            iconOnTable.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            iconOnTable.GetComponent<Button>().enabled = true;
            Destroy(gameObject);
        }
        else
        {
            this.transform.position = startPosition;
            iconOnTable.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        }
    }

    private void Update()
    {
        if (dialogue == null)
        {
            this.GetComponent<Button>().enabled = true;
        }
    }
}
