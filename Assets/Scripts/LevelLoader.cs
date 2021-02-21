using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float timeToWait = 4f;
    int curSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        curSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (curSceneIndex == 0)
        {
            StartCoroutine(WaitThenLoad());
        }
    }

    IEnumerator WaitThenLoad()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(curSceneIndex + 1);
    }

    public void LoadStartScreen()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
