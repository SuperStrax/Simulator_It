using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteCheck : MonoBehaviour
{
    public int connectCount;

    private void Update()
    {
        if (connectCount == 4)
            SceneManager.LoadScene(14);
    }
}
