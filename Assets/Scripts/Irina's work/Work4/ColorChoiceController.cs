using UnityEngine;

public class ColorChoiceController : MonoBehaviour
{
    public bool choiced = false;

    public void ColorChoice()
    {
        choiced = !choiced;
    }
}
