using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockedDoor : MonoBehaviour
{

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "StageOne" && Inventory.hasAllLauncherKeys)
        {
            gameObject.SetActive(false);
        }
        else if(SceneManager.GetActiveScene().name == "StageTwo" && Inventory.hasAllDimensionalKeys)
        {
            gameObject.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "StageThree" && Inventory.hasAllMiniKeys)
        {
            gameObject.SetActive(false);
        }
    }

}
