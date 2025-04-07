using UnityEngine;
using System.Collections;

public class FolleySoundScenePlayer : MonoBehaviour
{
    [System.Serializable]
    public class SoundClip
    {
        public AudioClip clip; // The audio clip to play
        public float interval; // Time interval in seconds to play the clip
        public float volume = 1f; // Volume of the sound clip (default is 1.0)

        public bool fade = true;
    }

    public SoundClip[] soundClips; // Array of sound clips with intervals
    private float[] timers; // Timers to track when to play each clip
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        StartCoroutine(PlaySoundClips());
    }

    private IEnumerator PlaySoundClips()
    {
        while (true)
        {
            for (int i = 0; i < soundClips.Length; i++)
            {
                StartCoroutine(FadeInAndPlay(soundClips[i].clip, soundClips[i].volume, soundClips[i].fade));
                yield return new WaitForSeconds(soundClips[i].interval); // Wait for the specified interval
            }
        }
    }
    private IEnumerator FadeInAndPlay(AudioClip clip, float targetVolume, bool fade)
    {
        if (clip == null)
        {
            Debug.LogWarning("AudioClip is null. Skipping playback.");
            yield break;
        }

        float fadeDuration = .5f; // Duration of fade in/out
        audioSource.clip = clip;
        audioSource.volume = 0f; // Start with volume at 0
        audioSource.Play();

        // Fade in
        if (audioSource != null && fade)
        {
            for (float t = 0; t < fadeDuration; t += Time.deltaTime)
            {
                audioSource.volume = Mathf.Lerp(0f, targetVolume, t / fadeDuration);
                yield return null;
            }
            audioSource.volume = targetVolume; // Set to the target volume
        }
        else if (audioSource != null)
        {
            audioSource.volume = targetVolume; // Immediately set to target volume if fadeDuration is invalid
        }

        // Wait for the clip to finish playing
        yield return new WaitForSeconds(clip.length);

        // Fade out
        if (fade)
        {
            for (float t = fadeDuration; t > 0; t -= Time.deltaTime)
            {
                audioSource.volume = Mathf.Lerp(0f, targetVolume, t / fadeDuration);
                yield return null;
            }
        }
        else
        {
            audioSource.volume = 0f; // Immediately set volume to 0 if no fade is required
        }

        audioSource.Stop();
    }
}
