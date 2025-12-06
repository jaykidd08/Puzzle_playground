using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;

[System.Serializable]
public class RecordData
{
    public string player_name;
    public string record_time;
}

public class DisplayHS : MonoBehaviour
{
    [Header("Stage Door Texts (3D TextMeshPro)")]
    public TextMeshPro stageOneText;
    public TextMeshPro stageTwoText;
    public TextMeshPro stageThreeText;
    public TextMeshPro stageFourText; // Add this when ready

    private string baseUrl = "http://localhost/PuzzlePlaygroundHighScore/";

    private void Start()
    {
        // Start coroutines for each stage
        StartCoroutine(LoadHighScores("stage_one_records", stageOneText));
        StartCoroutine(LoadHighScores("stage_two_records", stageTwoText));
        StartCoroutine(LoadHighScores("stage_three_records", stageThreeText));
        // StartCoroutine(LoadHighScores("stage_four_records", stageFourText)); // Uncomment when stage 4 is ready
    }

    IEnumerator LoadHighScores(string tableName, TextMeshPro textObject)
    {
        if (textObject == null)
        {
            Debug.LogWarning($"No TextMeshPro assigned for {tableName}");
            yield break;
        }

        WWWForm form = new WWWForm();
        form.AddField("table", tableName);

        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl + "displayScore.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string json = www.downloadHandler.text;
                Debug.Log($"Raw JSON from {tableName}: {json}");

                try
                {
                    RecordData[] records = JsonHelper.FromJson<RecordData>(json);
                    textObject.text = FormatLeaderboard(records);
                }
                catch (System.Exception e)
                {
                    textObject.text = "Error parsing scores!";
                    Debug.LogError($"JSON Parse Error for {tableName}: {e.Message}");
                }
            }
            else
            {
                textObject.text = "Error loading scores!";
                Debug.LogError($"Error loading {tableName}: {www.error} | Response: {www.downloadHandler.text}");
            }
        }
    }

    private string FormatLeaderboard(RecordData[] records)
    {
        string formatted = "";

        for (int i = 0; i < records.Length; i++)
        {
            string rank = $"#{i + 1}";
            string name = records[i].player_name;
            string time = records[i].record_time;

            if (float.TryParse(time, out float seconds))
            {
                int minutes = Mathf.FloorToInt(seconds / 60f);
                int sec = Mathf.FloorToInt(seconds % 60f);
                time = $"{minutes}:{sec:00}";
            }

            formatted += $"{rank} - {name}, {time}\n";
        }

        return formatted.TrimEnd();
    }
}

// JSON Helper class for Unity
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        string newJson = "{\"array\":" + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }
}
