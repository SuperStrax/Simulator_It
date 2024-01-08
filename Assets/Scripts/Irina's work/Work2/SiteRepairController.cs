using UnityEngine;

public class SiteRepairController : MonoBehaviour
{
    public GameObject button;
    public bool repairActivated;
    public GameObject shadows;
    public GameObject warning;
    public GameObject complete;
    public GameObject[] badBlocks;

    public void Repair()
    {
        repairActivated = !repairActivated;
        if (repairActivated)
        {
            shadows.SetActive(true);
        }
        else
        {
            shadows.SetActive(false);
        }
    }

    public void Save()
    {
        int badBlocksCounter = 0;
        foreach(GameObject badBlock in badBlocks)
        {
            if (badBlock != null)
            {
                badBlocksCounter++;
            }
        }
        if (badBlocksCounter != 0)
        {
            warning.SetActive(true);
        }
        else
        {
            complete.SetActive(true);
            Destroy(warning);
            Progress.Instance.levelsComplete[6] = true;
            Progress.Instance.SaveStat();
        }
    }
}
