using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class RockCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text rockCountText;
    [SerializeField] private TMP_Text rockCompletedText;
    [SerializeField] private GameObject cameraRig;
    [SerializeField] private GameObject planePrefab;
    [SerializeField] private List<GameObject> endGameObjectsToHide;
    [SerializeField] private List<GameObject> endGameObjectsToShow;
    [SerializeField] private TMP_Text endGameText;
    [SerializeField] private LessonManager lessonManager;
    private int totalRockCount = 0;

    public void EndGame()
    {
        // Move the camera rig to the location of the plane prefab
        cameraRig.transform.position = planePrefab.transform.position;
        cameraRig.transform.rotation = planePrefab.transform.rotation;
        // Hide the specified objects
        foreach (var obj in endGameObjectsToHide)
        {
            obj.SetActive(false);
        }

        // Show the specified objects
        foreach (var obj in endGameObjectsToShow)
        {
            obj.SetActive(true);
        }


        // Update the end game text
        endGameText.text = $"Total Rocks Collected: {totalRockCount}. (Must Collect 5 Rocks to Pass)";

        // Set rockCompletedText based on the rock count
        if (totalRockCount < 5)
        {
            rockCompletedText.text = "Task Failure";
        }
        else
        {
            rockCompletedText.text = "Task Complete";
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateRockCountText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearRockCount()
    {
        totalRockCount = 0;
        UpdateRockCountText();
    }
        

    public void IncrementRockCount()
    {
        totalRockCount++;
        UpdateRockCountText();
    }

    private void UpdateRockCountText()
    {
        rockCountText.text = totalRockCount.ToString();
    }


}
