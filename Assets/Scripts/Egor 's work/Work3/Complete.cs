using UnityEngine;

public class Complete : MonoBehaviour
{
    public GameObject completed;
    public Dialogue dialogue;
    public void Click()
     {
        completed.gameObject.SetActive(true);
        dialogue.gameObject.SetActive(true);
     }
}
