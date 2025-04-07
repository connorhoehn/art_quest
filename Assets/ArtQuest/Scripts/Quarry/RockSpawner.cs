using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private GameObject plane;
    [SerializeField] private int numberOfRocks = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRocks()
    {
        if (rockPrefab == null || plane == null) return;

        Renderer planeRenderer = plane.GetComponent<Renderer>();
        if (planeRenderer == null) return;

        Bounds bounds = planeRenderer.bounds;

        for (int i = 0; i < numberOfRocks; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                bounds.center.y,
                Random.Range(bounds.min.z, bounds.max.z)
            );

            Instantiate(rockPrefab, position, Quaternion.Euler(0, Random.Range(0, 360), 0));
        }
    }
}
