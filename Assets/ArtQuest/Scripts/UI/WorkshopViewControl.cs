using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;
public enum WorkshopStates
{
    OverviewPage,
    LessonsPage,
    CircleDrawingActivityPage,
    SquareDrawingActivityPage,
    Question1ActivityPage,
    Question2ActivityPage,
    LessonCompletePage,
    GameOverPage,
}

public class WorkshopViewControl : MonoBehaviour
{
    public static Action<WorkshopStates> WorkshopStateNotifier;
    [SerializeField] private List<GameObject> allGameObjectsToHide;

    [SerializeField] private List<GameObject> OverviewPage_objToShow;
    [SerializeField] private List<GameObject> LessonsPage_objToShow;
    [SerializeField] private List<GameObject> CircleDrawing_objToShow;
    [SerializeField] private List<GameObject> SquareDrawing_objToShow;
    [SerializeField] private List<GameObject> Question1Active_objToShow;
    [SerializeField] private List<GameObject> Question2Active_objToShow;
    [SerializeField] private List<GameObject> LessonEnd_objToShow;
    [SerializeField] private List<GameObject> GameOver_objToShow;
    [SerializeField] private WorkshopStates currentWorkshopState; // Tracks the current state in the scene
    [SerializeField] private bool autoUpdateState = false; // Checkbox to enable/disable state updates in Update()

    private ScoreManager scoreManager;
    public static WorkshopViewControl Instance;

    private void Awake()
    {
        if (Instance == null && Instance != this)
            Instance = this;
    }

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
        autoUpdateState = true;

    }

    void Update()
    {
        if (autoUpdateState)
        {
            UpdateViewBasedOnGameState(currentWorkshopState);
            autoUpdateState = false;
        }
    }

    public void GoToOverViewPage() {
        currentWorkshopState = WorkshopStates.OverviewPage;
        UpdateViewBasedOnGameState(currentWorkshopState);
    }

    /// <summary>
    /// Goes to the next state linearly
    /// </summary>
    public void GoToNextWorkShopState()
    {
        var index = (int)currentWorkshopState;
        index++;
        if (Enum.IsDefined(typeof(WorkshopStates), index))
            SetWorkshopState((WorkshopStates)index);

    }

    /// <summary>
    /// Updates the current workshop state 
    /// </summary>
    /// <param name="newState"></param>
    public void SetWorkshopState(WorkshopStates newState)
    {
        currentWorkshopState = newState;
        WorkshopStateNotifier?.Invoke(currentWorkshopState);
        UpdateViewBasedOnGameState(currentWorkshopState);
    }

    public void UpdateViewBasedOnGameState(WorkshopStates workshopState)
    {
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager is not initialized.");
            return;
        }

        var gameState = scoreManager.GetState();
        Debug.Log($"Current game state: {gameState}");

        Debug.Log("Current workshop state: " + workshopState);

        switch (workshopState)
        {
            case WorkshopStates.OverviewPage:
                HandleOverviewPageState();
                break;
            case WorkshopStates.LessonsPage:
                HandleLessonsPageState();
                break;
            case WorkshopStates.CircleDrawingActivityPage:
                HandleCircleDrawingStartState();
                break;
            case WorkshopStates.SquareDrawingActivityPage:
                HandleSquareDrawingStartState();
                break;
            case WorkshopStates.Question1ActivityPage:
                HandleQuestion1ActivityState();
                break;
            case WorkshopStates.Question2ActivityPage:
                HandleQuestion2ActivityState();
                break;
            case WorkshopStates.LessonCompletePage:
                HandleLessonCompleteState();
                break;
            case WorkshopStates.GameOverPage:
                HandleGameOverState();
                break;
            default:
                Debug.LogWarning("Unhandled workshop state.");
                break;
        }
    }

    private void HandleOverviewPageState()
    {
        SetActiveObjects(OverviewPage_objToShow);
    }

    private void HandleLessonsPageState()
    {
        SetActiveObjects(LessonsPage_objToShow);
    }

    private void HandleCircleDrawingStartState()
    {
        SetActiveObjects(CircleDrawing_objToShow);
    }

    private void HandleSquareDrawingStartState()
    {
        SetActiveObjects(SquareDrawing_objToShow);
    }

    private void HandleQuestion1ActivityState()
    {
        SetActiveObjects(Question1Active_objToShow);
    }
    private void HandleQuestion2ActivityState()
    {
        SetActiveObjects(Question2Active_objToShow);
    }

    private void HandleLessonCompleteState()
    {
        SetActiveObjects(LessonEnd_objToShow);
    }

    private void HandleGameOverState()
    {
        SetActiveObjects(GameOver_objToShow);
    }

    private IEnumerator SetActiveObjectsWithDelay(List<GameObject> objectsToShow, float delay)
    {
        // Hide all objects first
        foreach (var obj in allGameObjectsToHide)
        {
            if (obj != null) // Check if the object is not null
            {
                obj.SetActive(false);
            }
        }

        yield return new WaitForSeconds(delay); // Add delay before showing objects

        // Show only the relevant objects
        foreach (var obj in objectsToShow)
        {
            if (obj != null) // Check if the object is not null
            {
                obj.SetActive(true);
            }
        }
    }

    private void SetActiveObjects(List<GameObject> objectsToShow)
    {
        StartCoroutine(SetActiveObjectsWithDelay(objectsToShow, 0.5f)); // Default delay of 0.5 seconds
    }

}
