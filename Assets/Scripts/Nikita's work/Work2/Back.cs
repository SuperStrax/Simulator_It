using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    public GameObject nextLevel;

    public void back()
    {
        SceneManager.LoadScene(18);
    }

    private void Update()
    {
        if (nextLevel.activeInHierarchy)
            Destroy(gameObject);
    }
}
