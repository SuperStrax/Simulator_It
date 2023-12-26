using UnityEngine;

public class ProcessorRepairController : MonoBehaviour
{
    public GameObject cap;
    public ScrewdriverMove2 screwdriver;
    public GameObject radiator;
    public GameObject radiator2;
    public bool spirtContact;
    public Sprite clearProcessor;
    public bool processorContact;
    public bool pastaContact;
    public bool processorCleared;
    public Sprite processorWithPasta;
    public bool processorSmeared;
    public bool radiatorContact;
    public GameObject complete;

    public void capRemove()
    {
        if (screwdriver.pinCount == 8)
            cap.SetActive(false);
    }

    public void radiatorRemove()
    {
        radiator.SetActive(false);
        radiator2.SetActive(true);
    }

    private void Update()
    {
        if (screwdriver.pinCount == 0 && processorSmeared)
        {
            complete.SetActive(true);
            Progress.Instance.techLevelsComplete[4] = true;
            Progress.Instance.techStat = Progress.Instance.techStatCalc();
            Progress.Instance.SaveStat();
        }
    }
}
