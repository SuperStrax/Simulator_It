using UnityEngine;
using UnityEngine.UI;

public class AccessCheck : MonoBehaviour
{
    public GameObject fullAccess;
    public GameObject targetAccess;
    public GameObject[] allAccess;
    public GameObject complete;
    public GameObject warning;

    public void FullAccess()
    {
        fullAccess.GetComponent<AccesController>().Click();
        foreach (GameObject access in allAccess)
        {
            access.GetComponent<Image>().color = new Color32(0, 0, 0, 150);
            access.GetComponent<AccesController>().anotherButton.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        }
    }

    public void Accept()
    {
        if (targetAccess.GetComponent<Image>().color == new Color32(0, 0, 0, 150))
        {
            Destroy(warning);
            complete.SetActive(true);
            Progress.Instance.levelsComplete[13] = true;
            Progress.Instance.SaveStat();
        }
        else
            warning.SetActive(true);
    }

    private void Update()
    {
        foreach (GameObject access in allAccess)
        {
            if (access.GetComponent<Image>().color == new Color32(0, 0, 0, 0))
            {
                fullAccess.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                fullAccess.GetComponent<AccesController>().anotherButton.GetComponent<Image>().color = new Color32(0, 0, 0, 150);
            }
        }
    }
}
