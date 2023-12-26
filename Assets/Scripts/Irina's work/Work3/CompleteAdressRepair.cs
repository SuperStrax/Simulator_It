using UnityEngine;

public class CompleteAdressRepair : MonoBehaviour
{
    public GameObject complete;
    public GameObject badEnding;
    public InterfaceController controller;
    public GameObject[] elements;
    public GameObject[] interactiveElements;
    void Complete()
    {
        complete.SetActive(true);
    }

    void BadEnding()
    {
        controller.badEnding = true;
        badEnding.SetActive(true);
    }

    private void Update()
    {
        if (badEnding == null)
            Destroy(complete);
    }

    public void Click()
    {
        bool elementsLocated = true;
        foreach (GameObject element in interactiveElements)
        {
            if (element != null)
                elementsLocated = false;
        }

        if (elementsLocated)
        {
            bool completed = true;

            foreach (GameObject element in elements)
            {
                if (!element.activeInHierarchy)
                    completed = false;
            }

            if (completed)
            {
                Complete();
                Progress.Instance.progLevelsComplete[2] = true;
                Progress.Instance.techStat = Progress.Instance.progStatCalc();
                Progress.Instance.SaveStat();
            }
            else
                BadEnding();
        }
    }
}
