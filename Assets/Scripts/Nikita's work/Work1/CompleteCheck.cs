using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteCheck : MonoBehaviour
{
    public int connectCount;

    private void Update()
    {
        if (connectCount == 4)
        {
            SceneManager.LoadScene(17);
            Progress.Instance.sysLevelsComplete[0] = true;
            Progress.Instance.techStat = Progress.Instance.sysStatCalc();
            Progress.Instance.SaveStat();
        }
    }
}
