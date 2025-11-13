using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.SceneManagement;

public class UploadHS : MonoBehaviour
{
    public string playerName = "default player";
    private string tableName = "unknown_stage";
    private string baseUrl = "http://localhost/PuzzlePlaygroundHighScore/";

    private void Start()
    {
        // Set tableName based on the current stage
        string scene = SceneManager.GetActiveScene().name;
        switch (scene)
        {
            case "StageOne": tableName = "stage_one_records"; break;
            case "StageTwo": tableName = "stage_two_records"; break;
            case "StageThree": tableName = "stage_three_records"; break;
            case "StageFour": tableName = "stage_four_records"; break;
            default: tableName = "unknown_stage"; break;
        }

        // Set player name from ButtonManager (or any other source)
        playerName = ButtonManager.PlayerName;
    }

    public void UploadScore(float recordTime)
    {
        StartCoroutine(UploadRoutine(recordTime));
    }

    IEnumerator UploadRoutine(float recordTime)
    {
        WWWForm form = new WWWForm();
        form.AddField("table", tableName);
        form.AddField("player_name", playerName);
        form.AddField("record_time", recordTime.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl + "addScore.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log($"Upload Response ({tableName}): {www.downloadHandler.text}");
            }
            else
            {
                Debug.LogError($"Upload failed ({tableName}): {www.error} | Response: {www.downloadHandler.text}");
            }
        }
    }
}
