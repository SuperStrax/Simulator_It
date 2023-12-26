using UnityEngine;

public class SocketController : MonoBehaviour
{
    public GameObject socket;
    public GameObject videoPanel;
    void Update()
    {
        if (videoPanel.activeInHierarchy)
            socket.SetActive(false);
    }
}
