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
        StartCoroutine(Progress.Instance.GetPlayerId());
        Progress.Instance.GetPlayerId();
        Progress.Instance.LoadStat();
        techStat.text = Progress.Instance.techStat + "/5";
        progStat.text = Progress.Instance.progStat + "/5";
        sysStat.text = Progress.Instance.sysStat + "/5";
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
