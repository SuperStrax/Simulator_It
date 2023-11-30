using TMPro;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ProfessionChoiceController : MonoBehaviour
{
    public TextMeshProUGUI techStat;
    public TextMeshProUGUI progStat;
    public TextMeshProUGUI sysStat;

    int techStatCount = 0;
    int progStatCount = 0;
    int sysStatCount = 0;

    private void Start()
    {
        techStat.text = Convert.ToString(techStatCount) + "/5";
        progStat.text = Convert.ToString(progStatCount) + "/5";
        sysStat.text = Convert.ToString(sysStatCount) + "/5";
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
