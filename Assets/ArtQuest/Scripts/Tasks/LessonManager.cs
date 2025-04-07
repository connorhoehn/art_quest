using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class LessonManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] public UserTask UserTask;
    [SerializeField] private RockCounter rockCounter;

    [SerializeField] private List<GameObject> startGameObjectsToHide;
    [SerializeField] private List<GameObject> startGameObjectsToShow;

    private float timer = 30f;
    private bool gameStarted = false;
    [SerializeField] private GameObject cameraRig;
    [SerializeField] private GameObject teleportStart;
    public static LessonManager Instance;


    private void Awake()
    {
        // if (Instance == null && Instance != this)
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = timer.ToString();
    }

    public void ClearTimer()
    {
        gameStarted = false;
        timer = 30f;
        timerText.text = timer.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            timer -= Time.deltaTime;
            timerText.text = Mathf.Max(timer, 0).ToString("F0");

            if (timer <= 0)
            {
                Debug.Log("Timer is complete");
                ClearTimer();

                if (UserTask)
                {
                    UserTask.EndTask();
                    UserTask.DidCompletedTask(false);
                }
                if (rockCounter != null)
                {
                    rockCounter.EndGame();
                }
            }
        }
    }

    public void Logger()
    {
        Debug.Log("Timer is complete");
    }

    public void StartGame()
    {
        if (cameraRig == null || teleportStart == null)
        {
            Debug.LogError("Camera Rig or Teleport Start is not assigned.");
            return;
        }
        else
        {
            cameraRig.transform.position = teleportStart.transform.position;
            cameraRig.transform.rotation = teleportStart.transform.rotation;
        }

        foreach (var obj in startGameObjectsToHide)
        {
            obj.SetActive(false);
        }

        foreach (var obj in startGameObjectsToShow)
        {
            obj.SetActive(true);
        }

        gameStarted = true;
        timer = 30f;
    }
}
