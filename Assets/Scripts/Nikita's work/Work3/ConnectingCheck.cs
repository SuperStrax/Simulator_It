using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectingCheck : MonoBehaviour
{
    public GameObject line1;
    public GameObject line2;
    public GameObject line3;
    public GameObject ending;

    void Update()
    {
        if (line1 == null && line2 == null && line3 == null)
            ending.SetActive(true);
    }
}
