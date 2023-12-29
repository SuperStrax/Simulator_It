using UnityEngine;

public class MapComplete : MonoBehaviour
{
    public GameObject[] marks;
    public int placeCount = 0;
    public GameObject complete;
    public GameObject badEnding;
    public InterfaceController controller;
    public GameObject cafe;
    public GameObject administration;
    public GameObject monkey;
    public GameObject leos;
    public GameObject entrance;
    public GameObject rhino;
    public GameObject birds;


    public void Click()
    {
        if (placeCount == 7)
        {
            if (cafe.activeInHierarchy && administration.activeInHierarchy && monkey.activeInHierarchy && leos.activeInHierarchy
                 && entrance.activeInHierarchy && rhino.activeInHierarchy && birds.activeInHierarchy)
            {
                complete.SetActive(true);
                Progress.Instance.levelsComplete[9] = true;
                Progress.Instance.SaveStat();
            }
            else
            {
                controller.badEnding = true;
                controller.final = badEnding;
                badEnding.SetActive(true);
            }
        }
    }
}
