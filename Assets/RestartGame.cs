using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneResetter : MonoBehaviour
{
    public void ResetApp()
    {
        StartCoroutine(ReloadScene());
    }

    private IEnumerator ReloadScene()
    {

        ScoreManager.Instance.ResetState();

        // Load an empty scene asynchronously to purge persistent objects
        // AsyncOperation unloadOperation = SceneManager.LoadSceneAsync("EmptyScene");
        // while (!unloadOperation.isDone)
        // {
        //     yield return null; // Wait until the empty scene is fully loaded
        // }

        // Reload the main scene asynchronously after persistent objects are cleared
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(0);
        while (!loadOperation.isDone)
        {
            yield return null; // Wait until the main scene is fully loaded
        }
    }
}