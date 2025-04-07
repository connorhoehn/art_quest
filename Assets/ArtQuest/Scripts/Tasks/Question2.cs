using System.Collections;
using System.Collections.Generic;
using PaintIn3D;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Question2 : UserTask
{
    [SerializeField] List<Toggle> toggles;
    [SerializeField] GameObject footerCorrect;
    [SerializeField] GameObject footerWrong;
    [SerializeField] GameObject returnButton;
    string question2FailCountString = "QUESTION2FAILCOUNT";
    int question2FailCount;


    public override void OnEnable()
    {
        ResetTask();
    }
    private void Start()
    {
        question2FailCount = PlayerPrefs.GetInt(question2FailCountString, 0);
    }


    public override void DidCompletedTask(bool value)
    {
        base.DidCompletedTask(value);
        if (value)
        {
            //TO DO: Change to correct state
            // ScoreManager.Instance.SetState(GameState.Question2Pass);
            footerCorrect.SetActive(true);
            QuarryCelebrationSpawner.Instance.StartCelebration();
        }
        else
        {
            question2FailCount++;

            if (question2FailCount >= 2)
            {
                //Reset the saved count
                PlayerPrefs.SetInt(question2FailCountString, 0);
                ScoreManager.Instance.SetState(GameState.GameFailed);
                WorkshopViewControl.Instance.SetWorkshopState(WorkshopStates.GameOverPage);
                return;
            }
            else
            {
                PlayerPrefs.SetInt(question2FailCountString, question2FailCount);
                ScoreManager.Instance.SetState(GameState.Question2Fail);
                // WorkshopViewControl.Instance.SetWorkshopState(WorkshopStates.GameOverPage);
                footerWrong.SetActive(true);
            }
        }

        returnButton.SetActive(true);
        foreach (var child in toggles)
            child.interactable = false;
    }



    public void ExitTask()
    {
        WorkshopViewControl.Instance.SetWorkshopState(WorkshopStates.LessonsPage);
    }


    public override void ResetTask()
    {
        base.ResetTask();
        foreach (var child in toggles)
            child.interactable = true;

        footerCorrect.SetActive(false);
        footerWrong.SetActive(false);
        returnButton.SetActive(false);
    }

}
