using UnityEngine;
using UnityEngine.UI;

public class ObjectChoiceController : MonoBehaviour
{
    public Button rightButton;
    public Button wrongButton;
    bool activated = false;
    public GameObject whiteLine;
    public GameObject blackLine;
    public GameObject dialogue;

    public void ObjectChoice()
    {
        activated = !activated;

        if (activated)
        {
            gameObject.GetComponent<Image>().color = new Color32(116, 116, 116, 255);
            rightButton.enabled = true;
            wrongButton.enabled = true;
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            rightButton.enabled = false;
            wrongButton.enabled = false;
        }
    }

    private void Update()
    {
        if (dialogue == null)
            gameObject.GetComponent<Button>().enabled = true;

        if (activated && rightButton.gameObject.GetComponent<ColorChoiceController>().choiced)
        {
            whiteLine.SetActive(true);
            blackLine.SetActive(false);
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            rightButton.enabled = false;
            wrongButton.enabled = false;
            rightButton.gameObject.GetComponent<ColorChoiceController>().choiced = false;
            activated = false;
        }
        else if (activated && wrongButton.gameObject.GetComponent<ColorChoiceController>().choiced)
        {
            whiteLine.SetActive(false);
            blackLine.SetActive(true);
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            rightButton.enabled = false;
            wrongButton.enabled = false;
            wrongButton.gameObject.GetComponent<ColorChoiceController>().choiced = false;
            activated = false;
        }
    }
}
