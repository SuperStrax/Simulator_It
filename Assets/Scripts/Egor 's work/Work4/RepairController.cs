using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RepairController : MonoBehaviour
{
    public GameObject cap;
    public GameObject dialogue;
    public GameObject screwdriver;
    public GameObject holes;
    public GameObject redWire;
    public GameObject blackWire;
    public GameObject accumulator;
    public bool accumulatorFix = false;
    public int wireConnected = 0;

    private void Update()
    {
        if (dialogue == null && cap != null)
        {
            cap.GetComponent<Button>().enabled = true;
        }

        if (accumulatorFix && wireConnected == 2)
        {
            cap.SetActive(true);
            holes.SetActive(true);
        }

        if (wireConnected == 2 && screwdriver.GetComponent<ScrewdriverMove>().pinCount == 0)
            SceneManager.LoadScene(11);
    }

    public void capRemove()
    {
        if (screwdriver.GetComponent<ScrewdriverMove>().pinCount == 4 && wireConnected < 2)
        {
            cap.SetActive(false);
            holes.SetActive(false);
        }
    }

    public void blackWireChange()
    {
        if (accumulatorFix)
        {
            blackWire.SetActive(true);
            wireConnected++;
        }
        else
            blackWire.SetActive(false);
    }

    public void redWireChange()
    {
        if (accumulatorFix)
        {
            redWire.SetActive(true);
            wireConnected++;
        }
        else
            redWire.SetActive(false);
    }

    public void accumulatorRemove()
    {
        if(!redWire.activeInHierarchy && !blackWire.activeInHierarchy)
        accumulator.GetComponent<Image>().enabled = false;
    }
}
