using UnityEngine;
using UnityEngine.UI;

public class LineController : MonoBehaviour
{
    public bool crimperContact;
    public bool connectorContact;
    public bool bare;
    public Sprite bareLine;
    public GameObject lineWithConnector;
    public GameObject button;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.GetComponent<Image>().color = new Color32(0, 0, 0, 150);
        if (collision.gameObject.tag == "Crimper")
            crimperContact = true;
        else if(collision.gameObject.tag == "Connector")
            connectorContact = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        crimperContact = false;
        connectorContact = false;
    }
}
