using UnityEngine;

public class OpenMaket : MonoBehaviour
{
    public GameObject errorWindow;
    public GameObject programm;

    public void Error()
    {
        errorWindow.SetActive(true);
    }

    public void Open()
    {
        programm.SetActive(true);
    }
}
