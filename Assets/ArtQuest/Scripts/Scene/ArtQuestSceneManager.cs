using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ArtQuestSceneManager : MonoBehaviour
{
    public static ArtQuestSceneManager Instance { get; private set; }



    [SerializeField]
    private bool enableSceneOverride = false;

    [SerializeField]
    private int overrideSceneIndex = -1;
    string question1FailCountString = "QUESTION1FAILCOUNT";
    string question2FailCountString = "QUESTION2FAILCOUNT";


    private void Update()
    {
        if (enableSceneOverride && overrideSceneIndex >= 0)
        {
            SceneManager.LoadScene(overrideSceneIndex);
            enableSceneOverride = false;
            overrideSceneIndex = -1;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        //Reset the saved count
        PlayerPrefs.SetInt(question1FailCountString, 0);
        PlayerPrefs.SetInt(question2FailCountString, 0);

    }
    // Function to go to the main menu vista screen
    public void GoToMainMenuVistaScene()
    {
        SceneManager.LoadScene(1);
    }

    // Function to go to the main screen
    public void GoToWorkshopScene()
    {
        SceneManager.LoadScene(3);
    }

    // Function to go to the main screen
    public void GoToTutorialScene()
    {
        SceneManager.LoadScene(2);
    }

    // Function to go to the gathering scene
    public void GoToMainSquare()
    {
        SceneManager.LoadScene(4);
    }

    public void GoToQuarry()
    {
        SceneManager.LoadScene(5);
    }

}
