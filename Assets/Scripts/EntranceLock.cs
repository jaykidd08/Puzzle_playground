using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceLock : MonoBehaviour
{
    public GameObject stage2Lock;
    public GameObject stage3Lock;

    private void Start()
    {
        if (EndDoor.StageOneComplete)
        {
            stage2Lock.SetActive(false);
        }

        if (EndDoor.StageTwoComplete)
        {
            stage3Lock.SetActive(false);
        }
    }
}
