using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playtestManager : MonoBehaviour
{
    public GameObject playtestObjects;

    private void Start()
    {
        if (ButtonManager.PlaytestMode)
        {
            playtestObjects.SetActive(true);
        }
        else
        {
            playtestObjects.SetActive(false);  
        }
    }

}
