using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartDespawn : MonoBehaviour
{
    public GameObject ToolPartOne;
    public GameObject ToolPartTwo;
    public GameObject ToolPartThree;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "StageOne" && EndDoor.StageOneComplete) 
        {
            ToolPartOne.SetActive(false);
            ToolPartTwo.SetActive(false);
            ToolPartThree.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "StageTwo" && EndDoor.StageTwoComplete)
        {
            ToolPartOne.SetActive(false);
            ToolPartTwo.SetActive(false);
            ToolPartThree.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "StageThree" && EndDoor.StageThreeComplete)
        {
            ToolPartOne.SetActive(false);
            ToolPartTwo.SetActive(false);
            ToolPartThree.SetActive(false);
        }
    }
}
