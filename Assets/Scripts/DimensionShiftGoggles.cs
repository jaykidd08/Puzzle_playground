using System.Collections;
using System.Collections.Generic;
//using Cinemachine.Editor;
using UnityEngine;

public class DimensionShiftGoggles : MonoBehaviour
{
    [Header("Goggle Settings")]
    public float maxDuration = 4f;
    public float goggleCD = 2.5f;
    private KeyCode goggleToggle = KeyCode.Q;

    private bool goggleActive = false;
    private bool goggleOnCD = false;

    [Header("Dimensional Platforms")]
    public List<GameObject> dimensionalPlatforms;

    void Update()
    {
        if (ToolSelection.hasDimensionalGoggles)
        {
            if (Input.GetKeyDown(goggleToggle) && !goggleOnCD && !goggleActive)
            {
                StartCoroutine(ActivateGoggles());
            }
        }
    }

    public IEnumerator ActivateGoggles()
    {
        //Debug.Log("Coroutine Entered");
        goggleActive = true;
        TogglePlatforms(true);

        yield return new WaitForSeconds(maxDuration);

        goggleActive = false;
        TogglePlatforms(false);

        goggleOnCD = true;
        yield return new WaitForSeconds(goggleCD);
        goggleOnCD = false;

        //Debug.Log("Reached end of Coroutine");

    }

    void TogglePlatforms(bool toggle)
    {
        //Debug.Log("TogglePlatforms Entered");

        foreach (GameObject platform in dimensionalPlatforms)
        {
            if (platform != null)
            {
                platform.SetActive(toggle);
            }
            Debug.Log("foreach statement reached");
        }

        //Debug.Log("End of TogglePlatforms reached");
    }


}
