using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceLock : MonoBehaviour
{
    public GameObject stage2Lock;
    public GameObject stage3Lock;

    private void Start()
    {
        if (EndDoor.StageOneComplete && ToolSelection.hasLauncher)
        {
            stage2Lock.SetActive(false);
        }

        if (EndDoor.StageTwoComplete && ToolSelection.hasDimensionalGoggles)
        {
            stage3Lock.SetActive(false);
        }
    }
}
