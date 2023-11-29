using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceController : MonoBehaviour
{
    public GameObject skipButton;
    public GameObject hintButton;
    public int nextLevel;
    public GameObject final;
    public bool finalScene;
    public GameObject nextLevelButton;
    public bool badEnding;

    void Start()
    {
        InvokeRepeating("ShowCasualThings", 60, 60);
    }

    void ShowCasualThings()
    {
        if (!finalScene || (finalScene && final != null && !final.activeInHierarchy))
        {
            skipButton.SetActive(true);
            hintButton.SetActive(true);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    private void Update()
    {
        if (final == null && finalScene)
        {
            nextLevelButton.SetActive(true);
            if (badEnding)
                skipButton.SetActive(true);
        }
    }
}
