using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public GameObject dialogue;

   public void PowerPC()
    {
        gameObject.GetComponent<Image>().enabled = true;
        dialogue.SetActive(true);
        Progress.Instance.techLevelsComplete[0] = true;
        Progress.Instance.techStat = Progress.Instance.techStatCalc();
        Progress.Instance.SaveStat();
    }
}
