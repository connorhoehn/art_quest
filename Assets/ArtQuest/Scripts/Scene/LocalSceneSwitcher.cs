using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalSceneSwitcher : MonoBehaviour
{

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
