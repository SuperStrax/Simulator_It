using UnityEngine;

public class Complete : MonoBehaviour
{
    public GameObject completed;
    public Dialogue dialogue;
    public void Click()
     {
        completed.gameObject.SetActive(true);
        dialogue.gameObject.SetActive(true);
        Progress.Instance.techLevelsComplete[2] = true;
        Progress.Instance.techStat = Progress.Instance.techStatCalc();
        Progress.Instance.SaveStat();
    }
}
