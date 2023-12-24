using System.Collections;
using UnityEngine;

public class WindowsInstallController : MonoBehaviour
{
    public GameObject buttonC;
    public GameObject buttonE;
    public GameObject bios;
    public GameObject windows;
    public GameObject warning;
    public GameObject complete;

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(1);
        windows.SetActive(true);
        complete.SetActive(true);
    }

    public void InstallWindows()
    {
        if (!warning.activeInHierarchy)
        {
            bios.SetActive(false);
            StartCoroutine(Waiter());
        }
    }

    public void Warning()
    {
        warning.SetActive(true);
    }

    private void Update()
    {
        if (bios.activeInHierarchy)
        {
            if (Input.GetKey(KeyCode.Alpha1))
                InstallWindows();
            if (Input.GetKey(KeyCode.Alpha2))
                Warning();
        }
    }
}
