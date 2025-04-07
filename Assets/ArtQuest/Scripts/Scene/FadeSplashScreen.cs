using UnityEngine;
using System.Collections;

public class FadeSplashScreen : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(HandleSplashScreen());
    }

    private IEnumerator HandleSplashScreen()
    {
        yield return new WaitForSeconds(1f);

        // Keep canvas for 3 seconds
        yield return new WaitForSeconds(2f);

        // Fade out canvas
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = canvas.gameObject.AddComponent<CanvasGroup>();
        }

        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / 2f;
            yield return null;
        }

        canvas.gameObject.SetActive(false);

        // Go to main screen
        ArtQuestSceneManager sceneManager = ArtQuestSceneManager.Instance.GetComponent<ArtQuestSceneManager>();
        if (sceneManager != null)
        {
            sceneManager.GoToMainMenuVistaScene();
        }

    }

    private IEnumerator FadeCanvas()
    {
        yield return new WaitForSeconds(3f);

        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = canvas.gameObject.AddComponent<CanvasGroup>();
        }

        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / 2f;
            yield return null;
        }

        canvas.gameObject.SetActive(false);
    }

}
