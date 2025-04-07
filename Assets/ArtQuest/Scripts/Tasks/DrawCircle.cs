using System;
using System.Collections;
using PaintIn3D;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrawCircle : UserTask
{

    public GuideHandler GuideHandlerScript;
    GameObject currentTool;
    public GameObject StartButton;
    public GameObject DoneButton;



    private void ResetUI()
    {
        StartButton.SetActive(true);
        DoneButton.SetActive(false);
    }

    public override void StartTask()
    {
        base.StartTask();
        GuideHandlerScript.ActivateGuide(true);
        var tool = DrawingToolManager.Instance.GetNextTool(true);
        currentTool = Instantiate(tool.Prefab, GuideHandlerScript.gameObject.transform.position + Vector3.right * 0.4f + Vector3.up * 0.3f, Quaternion.Euler(Vector3.left * 270f));
        if (tool.overridePrefabSettings)
        {
            CwPaintSphere cwPaintSphere = currentTool.GetComponentInChildren<CwPaintSphere>();
            if (cwPaintSphere)
            {
                cwPaintSphere.Color = tool.InkColor;
                cwPaintSphere.Radius = tool.Thickness;
                cwPaintSphere.Hardness = tool.Hardness;
            }
            else
            {
                Debug.LogError("Can't find script to override settings");
            }
        }
        // StartCoroutine(StartTimer());
    }


    public override void EndTask()
    {
        base.EndTask();
        GuideHandlerScript.ActivateGuide(false);
        GuideHandlerScript.ClearGuide();
        Destroy(currentTool);

    }


    public override void DidCompletedTask(bool value)
    {
        base.DidCompletedTask(value);
        if (value)
        {
            ScoreManager.Instance.SetState(GameState.CircleDrawingComplete);
            QuarryCelebrationSpawner.Instance.StartCelebration();
        }
        WorkshopViewControl.Instance.SetWorkshopState(WorkshopStates.LessonsPage);
        GuideHandlerScript.gameObject.SetActive(false);
        ResetUI();
    }

    public override void ResetTask()
    {
        base.ResetTask();
        GuideHandlerScript.ClearGuide();
        GuideHandlerScript.ActivateGuide(true);

    }


}
