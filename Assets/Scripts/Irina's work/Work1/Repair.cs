using UnityEngine;
using UnityEngine.UI;

public class Repair : MonoBehaviour
{
    public GameObject correctElement;
    bool isWorking;
    public Button[] notCorrectElements;
    public Image repairColor;
    public bool chosen;
    public GameObject warning;
    public GameObject ending;

    public void RepairStart()
    {
        if (!warning.activeInHierarchy)
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
    }

    public void RepairElement()
    {
        if (!warning.activeInHierarchy)
        {
            correctElement.SetActive(true);
            this.gameObject.SetActive(false);
        }
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

    public void Save()
    {
        if (!warning.activeInHierarchy)
        {
            foreach (Button button in notCorrectElements)
            {
                if (button.gameObject.activeInHierarchy)
                {
                    warning.SetActive(true);
                    return;
                }
            }
            Destroy(warning);
            ending.SetActive(true);
            Progress.Instance.levelsComplete[5] = true;
            Progress.Instance.SaveStat();
        }
    }
}
