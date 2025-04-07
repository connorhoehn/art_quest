using UnityEngine;

public class SceneAudioPlayer : MonoBehaviour
{

	[SerializeField]
	private SceneType sceneType; // Select the scene type from a dropdown in the Inspector

	private void Start()
	{
		// Find the AudioManager singleton in the scene
		AudioManager audioManager = Object.FindFirstObjectByType<AudioManager>();

		if (audioManager == null)
		{
			Debug.LogError("AudioManager singleton not found in the scene.");
        } else {
			audioManager.PlaySceneAudioWithFade(sceneType, 0.5f);
        }
	}
}
