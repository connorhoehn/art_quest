using UnityEngine;
using UnityEngine.UI;

public class GameTaskActivator : MonoBehaviour
{
    private const string QDSUIBorderlessButton = "QDSUIBorderlessButton";
    private const string QDSUIPrimaryButton = "QDSUIPrimaryButton";

    [SerializeField]
    private Animator animator;

    private ScoreManager scoreManager;

    [SerializeField]
    private Image image;

    private Canvas canvas;

    [SerializeField]
    private GameState targetGameState; // Dropdown to select the target game state
    [SerializeField]
    private Toggle toggle;

    void Start()
    {
        // Try to find the GameStateSingleton object in the scene
        var gameStateSingleton = GameObject.FindWithTag("GameStateManager");

        if (gameStateSingleton != null)
        {
            // Get the component that contains the method to retrieve the current state
            this.scoreManager = gameStateSingleton.GetComponent<ScoreManager>(); // Ensure GameStateComponent is defined or its namespace is included
        }
        else
        {
            Debug.LogError("GameStateSingleton not found in the scene.");
            return;
        }

        // Search up the game object hierarchy until an active canvas is found
        Transform currentTransform = transform;
        while (currentTransform != null)
        {
            Canvas foundCanvas = currentTransform.GetComponent<Canvas>();
            if (foundCanvas != null && foundCanvas.isActiveAndEnabled)
            {
                canvas = foundCanvas;
                break;
            }
            currentTransform = currentTransform.parent;
        }

        if (canvas == null)
        {
            Debug.LogError("No active Canvas found in the hierarchy.");
        }
    }

    void Update()
    {

        // Check if the current game state matches the target game state
        bool shouldBeVisible = this.scoreManager.GetState() >= targetGameState;

        Debug.Log(this.scoreManager.GetState() + " >= " + targetGameState + " = " + shouldBeVisible);

        Debug.Log("Parent tag is " + transform.parent.tag);

        if (this.scoreManager && !shouldBeVisible)
        {
            toggle.interactable = false;
            toggle.enabled = false;
            animator.enabled = false;
            image.enabled = false;

            transform.parent.tag = QDSUIBorderlessButton;
            Canvas.ForceUpdateCanvases();

        }
        else
        {
            toggle.interactable = true;
            toggle.enabled = true;
            animator.enabled = true;
            image.enabled = true;
            transform.parent.tag = QDSUIPrimaryButton;
            Canvas.ForceUpdateCanvases();
        }
    }
}
