using UnityEngine;

public class ColorChoiceComplete : MonoBehaviour
{
    public GameObject[] lines;
    public GameObject[] whiteLines;
    public GameObject complete;
    public GameObject badEnding;
    public InterfaceController controller;

    private void Update()
    {
        int linesCount = 0;
        
        foreach (GameObject line in lines)
        {
            if (line.activeInHierarchy)
                linesCount++;
        }

        if (linesCount == 6)
        {
            int whiteLinesCount = 0;

            foreach (GameObject line in whiteLines)
            {
                if (line.activeInHierarchy)
                    whiteLinesCount++;
            }

            if (whiteLinesCount == 6)
                complete.SetActive(true);
            else
            {
                controller.badEnding = true;
                badEnding.SetActive(true);
                Destroy(complete);
            }
        }
    }
}
