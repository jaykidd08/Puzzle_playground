using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDoor : InteractableObject
{
    public Timer timer;

    public static bool StageOneComplete = false;
    public static bool StageTwoComplete = false;
    public static bool StageThreeComplete = false;
    public override void Interact()
    {
        Inventory.LauncherKeys = 0;
        Inventory.DimensionalKeys = 0;
        Inventory.MiniKeys = 0;
        timer.UpdateHighScore();

        if (SceneManager.GetActiveScene().name == "StageOne")
        {
            StageOneComplete = true;
        }
        else if (SceneManager.GetActiveScene().name == "StageTwo")
        {
            StageTwoComplete = true;
        }
        else if(SceneManager.GetActiveScene().name == "StageThree")
        {
            StageThreeComplete = true;
        }

            SceneManager.LoadScene("TheHub");
    }
}
