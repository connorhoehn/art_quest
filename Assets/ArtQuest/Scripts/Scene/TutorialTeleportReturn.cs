using UnityEngine;

public class TutorialTeleportReturn : MonoBehaviour
{
    [SerializeField] private GameObject cameraRig;
    [SerializeField] private GameObject startPointEmpty;
    private float timer = 0f;
    private float teleportInterval = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (cameraRig == null || startPointEmpty == null)
        {
            Debug.LogError("Camera Rig or Start Point Empty is not assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= teleportInterval)
        {
            TeleportToStartPoint();
            timer = 0f;
        }
    }

    private void TeleportToStartPoint()
    {
        Debug.Log("Teleport action started.");
        cameraRig.transform.position = startPointEmpty.transform.position;
        cameraRig.transform.rotation = startPointEmpty.transform.rotation;
    }
}
