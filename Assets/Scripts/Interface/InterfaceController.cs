using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceController : MonoBehaviour
{
    public GameObject skipButton;
    public GameObject hintButton;
    public int nextLevel;
    public int thisLevel;
    public GameObject final;
    public bool finalScene;
    public GameObject nextLevelButton;
    public bool badEnding;
    public GameObject restartLevel;

    void Start()
    {
        InvokeRepeating("ShowCasualThings", 60, 60);
        Progress.Instance.lastScene = thisLevel;
        StartCoroutine(Progress.Instance.SaveLevel());
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
        if (nextLevel == 18)
            PrinterProblemController.changeScene = false;
        SceneManager.LoadScene(nextLevel);
    }

    public void Restart()
    {
        SceneManager.LoadScene(thisLevel);
    }

    private void Update()
    {
        if (final == null && finalScene)
        {
            if (badEnding)
            {
                skipButton.SetActive(true);
                restartLevel.SetActive(true);
            }
            else
            {
                nextLevelButton.SetActive(true);
            }
        }
    }
}
