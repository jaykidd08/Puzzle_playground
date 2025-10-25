using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class StageRecord : MonoBehaviour
{
    private int seconds;
    private int minutes;
    private string secondFormat;
    private void Start()
    {
        if (gameObject.name == "StageOneRecord") 
        {
            if (EndDoor.StageOneComplete)
            {
                seconds = (int)(Timer.StageOneHighScore % 60);
                minutes = (int)(Timer.StageOneHighScore / 60);
                secondFormat = seconds.ToString("00");

                gameObject.GetComponent<TextMeshPro>().text = "Record:\n" + minutes + ":" + secondFormat;
            }
        }
        else if (gameObject.name == "StageTwoRecord")
        {
            if (EndDoor.StageTwoComplete)
            {
                seconds = (int)(Timer.StageTwoHighScore % 60);
                minutes = (int)(Timer.StageTwoHighScore / 60);
                secondFormat = seconds.ToString("00");

                gameObject.GetComponent<TextMeshPro>().text = "Record:\n" + minutes + ":" + secondFormat;
            }
        }
        else if (gameObject.name == "StageThreeRecord")
        {
            if (EndDoor.StageThreeComplete)
            {
                seconds = (int)(Timer.StageThreeHighScore % 60);
                minutes = (int)(Timer.StageThreeHighScore / 60);
                secondFormat = seconds.ToString("00");

                gameObject.GetComponent<TextMeshPro>().text = "Record:\n" + minutes + ":" + secondFormat;
            }
        }
    }
}
