using UnityEngine;

public class SetupDriver : MonoBehaviour
{
    public GameObject setupWindow;
    public GameObject errorWindow;
    public GameObject dialogue;
    public GameObject backButton;

    public void Setup()
    {
        setupWindow.SetActive(true);
        dialogue.SetActive(true);
        backButton.SetActive(false);
        Progress.Instance.sysLevelsComplete[1] = true;
        Progress.Instance.techStat = Progress.Instance.sysStatCalc();
        Progress.Instance.SaveStat();
    }

    public void Error()
    {
        errorWindow.SetActive(true);
        this.gameObject.SetActive(false);
        backButton.SetActive(false);
    }

    public void closeError()
    {
        errorWindow.SetActive(false);
        backButton.SetActive(true);
    }
}
