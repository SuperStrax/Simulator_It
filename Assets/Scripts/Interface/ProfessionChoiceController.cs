using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProfessionChoiceController : MonoBehaviour
{
    public TextMeshProUGUI techStat;
    public TextMeshProUGUI progStat;
    public TextMeshProUGUI sysStat;

    private void Start()
    {
        Progress.Instance.LoadStat();
        techStat.text = Progress.Instance.techStatCalc() + "/5";
        progStat.text = Progress.Instance.progStatCalc() + "/5";
        sysStat.text = Progress.Instance.sysStatCalc() + "/5";
    }

    public void techinicianStart()
    {
        SceneManager.LoadScene(2);
    }

    public void programmerStart()
    {
        SceneManager.LoadScene(14);
    }

    public void sysAdminStart()
    {
        SceneManager.LoadScene(15);
    }
}
