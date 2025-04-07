using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuarryCelebrationSpawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public int numberOfProps = 10;
    public static QuarryCelebrationSpawner Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

    }


    private IEnumerator DeleteAfterSeconds(GameObject obj, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(obj);
    }

    [ContextMenu("start celebration")]
    public void StartCelebration()
    {
        StartCoroutine(SpawnPrefabs());
    }

    private IEnumerator SpawnPrefabs()
    {
        // transform.position = Camera.main.transform.position + Vector3.up * 7f;
        yield return new WaitForSeconds(0.2f);
        var cameraPos = Camera.main.transform.position;

        for (int i = 0; i < numberOfProps; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-4f, 4f),
                0f,
                Random.Range(-4f, 4f)
            );

            Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            GameObject prefab = prefabs[Random.Range(0, prefabs.Count)];
            GameObject spawnedObject = Instantiate(prefab, cameraPos + randomPosition, randomRotation);
            spawnedObject.transform.localScale = new Vector3(3.3f, 3.3f, 3.3f);
            StartCoroutine(DeleteAfterSeconds(spawnedObject, 2f));

            yield return new WaitForSeconds(2f / numberOfProps);
        }
    }
}