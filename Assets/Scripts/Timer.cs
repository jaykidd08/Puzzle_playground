
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer;
    private int seconds;
    private int minutes;
    private string secondFormat;

    public static float StageOneHighScore = 250000f;
    public static float StageTwoHighScore = 250000f;
    public static float StageThreeHighScore = 250000f;
    void Start()
    {
        timer = 0.0f;
        GameObject.Find("TimerUI").GetComponent<TextMeshProUGUI>().text = "0:00";

        if (SceneManager.GetActiveScene().name == "StageOne")
        {
            if (EndDoor.StageOneComplete)
            {
                seconds = (int)(Timer.StageOneHighScore % 60);
                minutes = (int)(Timer.StageOneHighScore / 60);
                secondFormat = seconds.ToString("00");

                GameObject.Find("HighScoreUI").GetComponent<TextMeshProUGUI>().text = "Record:\n" + minutes + ":" + secondFormat;
            }
        }
        else if (SceneManager.GetActiveScene().name == "StageTwo")
        {
            if (EndDoor.StageTwoComplete)
            {
                seconds = (int)(Timer.StageTwoHighScore % 60);
                minutes = (int)(Timer.StageTwoHighScore / 60);
                secondFormat = seconds.ToString("00");

                GameObject.Find("HighScoreUI").GetComponent<TextMeshProUGUI>().text = "Record:\n" + minutes + ":" + secondFormat;
            }
        }
        else if (SceneManager.GetActiveScene().name == "StageThreeRecord")
        {
            if (EndDoor.StageThreeComplete)
            {
                seconds = (int)(Timer.StageThreeHighScore % 60);
                minutes = (int)(Timer.StageThreeHighScore / 60);
                secondFormat = seconds.ToString("00");

                GameObject.Find("HighScoreUI").GetComponent<TextMeshProUGUI>().text = "Record:\n" + minutes + ":" + secondFormat;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)(timer % 60);
        minutes = (int)(timer / 60);
        secondFormat = seconds.ToString("00");
        GameObject.Find("TimerUI").GetComponent<TextMeshProUGUI>().text = "" + minutes + ":" + secondFormat;
        //Debug.Log(minutes + ":" + seconds);
    }

    public void UpdateHighScore()
    {
        if (SceneManager.GetActiveScene().name == "StageOne")
        {
            if (timer < StageOneHighScore)
            {
                StageOneHighScore = timer;
                FindObjectOfType<UploadHS>().UploadScore(timer);
            }
        }
        else if (SceneManager.GetActiveScene().name == "StageTwo")
        {
            if (timer < StageTwoHighScore)
            {
                StageTwoHighScore = timer;
                FindObjectOfType<UploadHS>().UploadScore(timer);
            }
        }
        else if (SceneManager.GetActiveScene().name == "StageThree")
        {
            if (timer < StageThreeHighScore)
            {
                StageThreeHighScore = timer;
                FindObjectOfType<UploadHS>().UploadScore(timer);
            }
        }
    }
}
