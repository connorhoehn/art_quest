using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class QuarryActivityManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private List<GameObject> allGameObjects;
    [SerializeField] private List<GameObject> gameStartObjects;
    [SerializeField] private List<GameObject> gameEndObjects;
    [SerializeField] private TMP_Text endGameTotalRocksCollected;
    [SerializeField] private TMP_Text taskCompletionResults;
    [SerializeField] private TMP_Text totalRocksCountedText;
    [SerializeField] private GameObject cameraRig;
    [SerializeField] private GameObject stoneCollectionStartingPoint;
    [SerializeField] private GameObject gameStartEndPoint;
    [SerializeField] private GameObject uiParent;

    [SerializeField] private AudioClip rockPlacementInWagonSoundClip;
    [SerializeField] private AudioClip taskSuccessSoundClip;
    [SerializeField] private AudioClip taskFailureSoundClip;
    [SerializeField] private AudioClip celebrationSoundClip;

    [SerializeField] private AudioClip stopWatchSoundClip;


    [SerializeField] private QuarryCelebrationSpawner quarryCelebrationSpawner;

    private float timer = 30f;
    private bool gameStarted = false;
    private int totalRockCount = 0;

    private HashSet<string> countedRocks = new HashSet<string>();

    [SerializeField] private bool simulateGameStartInEditor = false;
    [SerializeField] private bool simulateGameEndInEditor = false;
    private void Start()
    {
        // StartCoroutine(SetUI(0.5f));
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
                EndGame();
            }
        }

        if (simulateGameEndInEditor && gameStarted)
        {
            EndGame();
        }
    }

    void OnGUI()
    {
        if (Application.isEditor)
        {
            simulateGameStartInEditor = GUILayout.Toggle(simulateGameStartInEditor, "Simulate Game Start in Editor");
            if (simulateGameStartInEditor && !gameStarted)
            {
                StartGame();
            }

            simulateGameEndInEditor = GUILayout.Toggle(simulateGameEndInEditor, "Simulate Game End in Editor");
            if (simulateGameEndInEditor && gameStarted)
            {
                EndGame();
            }
        }
    }

    private IEnumerator<object> HideGameObjectsWithDelay(float delay, List<GameObject> gameObjectsToShow)
    {
        yield return new WaitForSeconds(delay);
        HideAllGameObjects();
        if (gameObjectsToShow != null)
        {
            SetActiveGameObjects(gameObjectsToShow, true);
        }
        else
        {
            Debug.LogError("gameObjectsToShow list is not assigned.");
        }
    }

    public void StartGame()
    {
        gameStarted = true;
        if (cameraRig == null || stoneCollectionStartingPoint == null)
        {
            Debug.LogError("Camera Rig or Teleport Start is not assigned.");
            return;
        }
        else
        {
            cameraRig.transform.position = stoneCollectionStartingPoint.transform.position;
            cameraRig.transform.rotation = stoneCollectionStartingPoint.transform.rotation;
        }

        HideAllGameObjects();
        SetActiveGameObjects(gameStartObjects, true);

        // Start the timer and set gameStarted to true
        ResetTimer();
        gameStarted = true;
    }

    public void EndGame()
    {

        gameStarted = false;

        if (allGameObjects != null)
        {
            HideAllGameObjects();
        }
        else
        {
            Debug.LogError("allGameObjects list is not assigned.");
        }

        if (gameEndObjects != null)
        {
            SetActiveGameObjects(gameEndObjects, true);
        }
        else
        {
            Debug.LogError("gameEndObjects is not assigned.");
        }

        // Update the end game text
        endGameTotalRocksCollected.text = $"Total Rocks Collected: {totalRockCount}. (Must Collect 5 Rocks to Pass)";

        bool completedTask = true;
        // Set taskCompletionResults based on the rock count
        if (totalRockCount < 5)
        {
            taskCompletionResults.text = "Task Failure";
            completedTask = false;

            ScoreManager.Instance.SetState(GameState.ScholarshipFailedFirstTry);
        }
        else
        {
            taskCompletionResults.text = "Task Complete";
            completedTask = true;
            ScoreManager.Instance.SetState(GameState.ScholarshipCompleted);

        }

        countedRocks.Clear();

        if (cameraRig == null || gameStartEndPoint == null)
        {
            Debug.LogError("Camera Rig or Teleport Start is not assigned.");
            return;
        }
        else
        {
            cameraRig.transform.position = gameStartEndPoint.transform.position;
            cameraRig.transform.rotation = gameStartEndPoint.transform.rotation;
        }

        StartCoroutine(SetUI(0f));

        if (completedTask && quarryCelebrationSpawner != null)
        {
            quarryCelebrationSpawner.StartCelebration();
            PlayQuarryCelebrationSoundClip();
        }
        else
        {
            PlayQuarryFailureSoundClip();
        }
    }

    public void PlayQuarryFailureSoundClip()
    {
        if (taskFailureSoundClip != null)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.PlayOneShot(taskFailureSoundClip);
            }
            else
            {
                Debug.LogError("AudioSource component is missing on the GameObject.");
            }
        }
        else
        {
            Debug.LogError("Failure sound clip is not assigned.");
        }
    }

    public void PlayQuarryCelebrationSoundClip()
    {
        if (celebrationSoundClip != null)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.PlayOneShot(celebrationSoundClip);
                audioSource.PlayOneShot(taskSuccessSoundClip);
            }
            else
            {
                Debug.LogError("AudioSource component is missing on the GameObject.");
            }
        }
        else
        {
            Debug.LogError("Celebration sound clip is not assigned.");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void HideAllGameObjects()
    {
        if (allGameObjects != null)
            SetActiveGameObjects(allGameObjects, false);
    }

    private void SetActiveGameObjects(List<GameObject> gameObjects, bool isActive)
    {
        if (gameObjects != null)
        {
            foreach (var obj in gameObjects)
            {
                if (obj != null)
                {
                    obj.SetActive(isActive);
                }
                else
                {
                    Debug.LogError("The gameObject is null or has been destroyed.");
                }

            }
        }
        else
        {
            Debug.LogError("gameObjects list is not assigned.");
        }
    }

    [ContextMenu("Increase rock count")]
    public void IncrementTotalRockCount()
    {
        totalRockCount++;
        UpdateRockCountText();
    }

    private void UpdateRockCountText()
    {
        totalRocksCountedText.text = totalRockCount.ToString();
    }

    public void ResetTimer()
    {
        timer = 30f;
        timerText.text = timer.ToString("F0");
    }

    public int GetTotalRockCount()
    {
        return totalRockCount;
    }

    public void OnRockEntered(string rockID)
    {
        if (!countedRocks.Contains(rockID))
        {
            countedRocks.Add(rockID);
            IncrementTotalRockCount();
        }
    }

    IEnumerator SetUI(float delay)
    {
        yield return new WaitForSeconds(delay);
        Transform myCamera = Camera.main.transform;

        float offsetDistance = 1f;
        Vector3 forward = myCamera.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 cameraPos = myCamera.position;
        cameraPos.y = 0f;


        uiParent.transform.position = cameraPos + forward * offsetDistance;
        uiParent.transform.rotation = Quaternion.Euler(0, myCamera.eulerAngles.y, 0);
    }

    public void GoToWorkshopScene()
    {
        ArtQuestSceneManager.Instance.GoToWorkshopScene();
    }



}