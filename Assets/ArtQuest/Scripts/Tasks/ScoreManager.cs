using UnityEngine;
using System.Collections.Generic;

public enum GameState
{
    NotStarted,
    ScholarshipFailedFirstTry,
    ScholarshipCompleted,
    CircleDrawingComplete,
    SquareDrawingComplete,
    Question1Fail,
    Question1Pass,
    Question2Fail,
    Question2Pass,
    Lesson1Passed,
    Lesson1Failed,
    MixPigmentsComplete,
    MixPigmentsFail,
    MixMeduimComplete,
    MixMeduimFail,
    Question3Pass,
    Question3Fail,
    GameFailed
}

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private bool checkBox; // Checkbox visible in the Unity Editor

    [SerializeField]
    private GameState currentState;

    private static ScoreManager instance;

    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<ScoreManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("ScoreManager");
                    instance = obj.AddComponent<ScoreManager>();
                }
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        checkBox = true;
    }




    // Update is called once per frame
    void Update()
    {
        if (checkBox)
        {
            PerformAction();
            checkBox = false; // Reset the checkbox after the action is performed
        }
    }

    private void PerformAction()
    {
        Debug.Log("Checkbox is checked! Performing action...");
        Debug.Log("GameState: " + currentState);
        // Add your desired functionality here
        SetState(currentState);
    }

    public bool DidFailFirstScholarshipTry()
    {
        return currentState == GameState.ScholarshipFailedFirstTry;
    }

    public bool DidFinishScholarshipStage()
    {
        return currentState == GameState.ScholarshipCompleted;
    }

    public bool HasFinishedBeginnerLevel()
    {
        return currentState == GameState.CircleDrawingComplete || currentState == GameState.SquareDrawingComplete;
    }

    public bool GetAllTasksComplete()
    {
        return currentState <= GameState.Lesson1Passed;
    }

    public bool HasCompletedTask(GameState task)
    {
        return currentState == task;
    }

    public bool isInScholarshipFailedFirstTry()
    {
        return currentState == GameState.ScholarshipFailedFirstTry;
    }

    public void SetState(GameState newState)
    {
        //No need to go back to a previous state
        //If we have completed a state and we come back to do the task at a later time, prevent resetting the game state
        if ((int)newState > (int)currentState)
            currentState = newState;
    }

    public GameState GetState()
    {
        return currentState;
    }


    /// <summary>
    /// Called when you want to restart the game
    /// </summary>

    public void ResetState()
    {
        currentState = GameState.NotStarted;
    }
}