using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Repair : MonoBehaviour
{
    public GameObject correctElement;
    bool isWorking;
    public Button[] notCorrectElements;
    public Image repairColor;
    public bool chosen;

    public void RepairStart()
    {
        if (!isWorking)
        {
            isWorking = true;
            repairColor.color = new Color32(70, 84, 150, 140);
            foreach (Button button in notCorrectElements)
            {
                button.enabled = true;
            }
        }
        else
        {
            isWorking = false;
            repairColor.color = new Color32(70, 84, 150, 0);
            foreach (Button button in notCorrectElements)
            {
                button.enabled = false;
            }
        }
    }

    public void RepairElement()
    {
        correctElement.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void OnMouseEnter()
    {
        if (chosen && repairColor.color == new Color32(70, 84, 150, 140))
        {
            this.GetComponent<Image>().color = new Color32(255, 255, 255, 125);
        }
    }

    public void OnMouseExit()
    {
        if (chosen && repairColor.color == new Color32(70, 84, 150, 140))
        {
            this.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}
