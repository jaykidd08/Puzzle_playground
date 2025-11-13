using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "PlatformWall")
        {
            ContactPoint platformPoint = collision.contacts[0];
            Vector3 normal = platformPoint.normal;
            PlatformManager.Instance.SpawnPlatform(platform, platformPoint.point, normal);

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
