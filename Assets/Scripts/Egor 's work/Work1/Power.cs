using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public GameObject dialogue;

   public void PowerPC()
    {
        gameObject.GetComponent<Image>().enabled = true;
        dialogue.SetActive(true);
        Progress.Instance.levelsComplete[0] = true;
        Progress.Instance.SaveStat();
    }
}
