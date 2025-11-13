using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance { get; private set; }

    public int maxPlatforms = 3;

    private Queue<GameObject> platforms = new Queue<GameObject>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void SpawnPlatform(GameObject platformPrefab, Vector3 position, Vector3 normal)
    {

        if (platforms.Count >= maxPlatforms)
        {
            GameObject oldPlatform = platforms.Dequeue();
            Destroy(oldPlatform);
        }

        Quaternion rotation = Quaternion.LookRotation(-normal);

        Vector3 spawnPosition = position + normal * 1.01f;

        GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, rotation);
        platforms.Enqueue(newPlatform);
    }
}
