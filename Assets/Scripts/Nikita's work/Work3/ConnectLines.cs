using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectLines : MonoBehaviour
{
    public GameObject connectedLine;

    public void Connect()
    {
        connectedLine.SetActive(true);
        Destroy(gameObject);
    }
}
