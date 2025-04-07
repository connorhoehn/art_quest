using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class RockInWagonCounter : MonoBehaviour
{
    [SerializeField]
    private QuarryActivityManager quarryActivityManager;
    
    [SerializeField]
    private AudioClip rockEnterSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (quarryActivityManager == null)
        {
            Debug.LogWarning("QuarryActivityManager component is not assigned. Attempting to find it.");
            GameObject quarryTaskManagerObject = GameObject.Find("QuarryTaskManager");
            if (quarryTaskManagerObject != null)
            {
                quarryActivityManager = quarryTaskManagerObject.GetComponent<QuarryActivityManager>();
                if (quarryActivityManager == null)
                {
                    Debug.LogError("QuarryActivityManager component not found on QuarryTaskManager object.");
                }
            }
            else
            {
                Debug.LogError("QuarryTaskManager object not found in the scene.");
            }
        }
    }

    // This method is called when another collider enters the trigger collider attached to the object where this script is attached
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object entered: " + other.gameObject.name);
        if (quarryActivityManager != null)
        {
            quarryActivityManager.OnRockEntered(other.gameObject.GetInstanceID().ToString());
        }

        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.PlayOneShot(rockEnterSound);
        }
        else
        {
            Debug.LogError("AudioSource component is missing on the GameObject.");
        }

    }
}
