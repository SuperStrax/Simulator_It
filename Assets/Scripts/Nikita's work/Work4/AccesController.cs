using UnityEngine;
using UnityEngine.UI;

public class AccesController : MonoBehaviour
{
    public GameObject anotherButton;

    public void Click()
    {
        if (gameObject.GetComponent<Image>().color == new Color32(0, 0, 0, 150))
        {
            gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
            anotherButton.GetComponent<Image>().color = new Color32(0, 0, 0, 150);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 150);
            anotherButton.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        }
    }
}
