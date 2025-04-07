using System.Collections;
using System.Collections.Generic;
using PaintIn3D;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Question1 : UserTask
{
    [SerializeField] List<Toggle> toggles;
    [SerializeField] GameObject footerCorrect;
    [SerializeField] GameObject footerWrong;
    [SerializeField] GameObject returnButton;
    string question1FailCountString = "QUESTION1FAILCOUNT";
    int question1FailCount;


    public override void OnEnable()
    {
        ResetTask();
    }
    private void Start()
    {
        question1FailCount = PlayerPrefs.GetInt(question1FailCountString, 0);
    }


    public override void DidCompletedTask(bool value)
    {
        base.DidCompletedTask(value);
        if (value)
        {
            ScoreManager.Instance.SetState(GameState.Question1Pass);
            footerCorrect.SetActive(true);
            QuarryCelebrationSpawner.Instance.StartCelebration();
        }
        else
        {
            question1FailCount++;

            if (question1FailCount >= 2)
            {
                //Reset the saved count
                PlayerPrefs.SetInt(question1FailCountString, 0);
                ScoreManager.Instance.SetState(GameState.GameFailed);
                WorkshopViewControl.Instance.SetWorkshopState(WorkshopStates.GameOverPage);
                return;
            }
            else
            {
                PlayerPrefs.SetInt(question1FailCountString, question1FailCount);
                ScoreManager.Instance.SetState(GameState.Question1Fail);
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
