using UnityEngine;
using System.Collections.Generic; // Ensure Dictionary is available
public enum SceneType
{
    Splash,
    MainMenu,
    Workshop,
    Quarry,
    Tutorial,
    TownGathering
}

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    [SerializeField] private AudioClip splashScreenLoop;
    [SerializeField] private AudioClip mainMenuLoop;
    [SerializeField] private AudioClip workshopLoop;
    [SerializeField] private AudioClip quarryLoop;
    [SerializeField] private AudioClip tutorialLoop;
    [SerializeField] private AudioClip townGatheringLoop;

    private Dictionary<SceneType, AudioClip> sceneAudioClips;

    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = gameObject.AddComponent<AudioSource>();

            sceneAudioClips = new Dictionary<SceneType, AudioClip>
            {
                { SceneType.Splash, splashScreenLoop },
                { SceneType.MainMenu, mainMenuLoop },
                { SceneType.Workshop, workshopLoop },
                { SceneType.Quarry, quarryLoop },
                { SceneType.Tutorial, tutorialLoop },
                { SceneType.TownGathering, townGatheringLoop }
            };
        }
        else
        {
            Destroy(gameObject);
        }
    }
        
    public void PlaySceneAudioWithFade(SceneType scene, float fadeDuration = 0.5f)
    {
        if (sceneAudioClips.TryGetValue(scene, out AudioClip clip))
        {
            StartCoroutine(FadeInAudio(clip, fadeDuration));
        }
        else
        {
            Debug.LogWarning($"No audio clip found for scene: {scene}");
        }
    }

    private System.Collections.IEnumerator FadeInAudio(AudioClip clip, float duration)
    {
        audioSource.clip = clip;
        audioSource.volume = 0f;
        audioSource.loop = true;
        audioSource.Play();
    
        float targetVolume = clip == workshopLoop ? 0.7f : 1f;
    
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            audioSource.volume = Mathf.Lerp(0f, targetVolume, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        audioSource.volume = targetVolume;
    }
}
