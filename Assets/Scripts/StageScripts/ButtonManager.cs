using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static string PlayerName;
    public static bool PlaytestMode = false;

    public GameObject pageOverlay;
    public TextMeshProUGUI pageText;
    public TMP_InputField playerNameInput;
    public Toggle playtestSwitch;

    private void Start()
    {
        playtestSwitch.isOn = PlaytestMode;
        playerNameInput.text = PlayerName;
    }

    public void StartGame()
    {
        if (PlaytestMode)
        {
            Debug.Log("Starting game for " + PlayerName + " with playtest mode");
        }
        else
        {
            Debug.Log("Starting game for " + PlayerName + " without playtest mode");
        }

        SceneManager.LoadScene("TheHub");
    }

    public void PlaytestInfo()
    {
        pageText.fontSize = 30f;
        pageOverlay.SetActive(true);
        pageText.text = "When the above \"Playtest Mode\" has a checkmark visible the game will enter playtest! " +
            "When this mode is active, some features of the game will be disabled, but the levels will be easier to traverse. " +
            "Available Features: \n\t1. Playtest platforms\n\t2. Educational Material " +
            "\n\t3. Tool crafting \n\t4. Personal Stage Records \n\t5. Current Leaderboard Positions \n" +
            "Disabled Features: \n\t1. Leaderboard Updating";
    }

    public void GameInfo()
    {
        pageText.fontSize = 26f;
        pageOverlay.SetActive(true);
        pageText.text = "Important Controls:\n" +
            "Move around the gameworld with \"WASD\"!\n" +
            "Press the \"Escape\" key to pause the game!\n" +
            "You can find keybinds in the pause menu!\n\n" +
            "Game Mechanics: \n" +
            "You start with a grappling hook.\n" +
            "Every stage will have you gather tool parts.\n" +
            "Collecting all parts in a stage unlocks the ability to " +
            "craft a new tool in the hub and continue to the next stage\n" +
            "Every stage will have a record for you to try and improve\n" +
            "After your first completion tools parts will be removed so you can focus on beating previous scores\n\n" +
            "Educational Material: \n" +
            "When tool parts are picked up a note will appear " +
            "displaying a portion of code used to create the tool.";
    }

    public void HideInfo()
    {
        pageOverlay.SetActive(false);
        pageText.text = "";
    }

    public void PlayerNameUpdate(string pn)
    {
        PlayerName = pn;
    }

    private void OnEnable()
    {
        playtestSwitch.onValueChanged.AddListener(PlaytestToggle);
        playerNameInput.onValueChanged.AddListener(PlayerNameUpdate);
    }

    private void OnDisable()
    {
        playtestSwitch.onValueChanged.RemoveListener(PlaytestToggle);
        playerNameInput.onValueChanged.RemoveListener(PlayerNameUpdate);
    }

    public void PlaytestToggle(bool toggle)
    {
        PlaytestMode = toggle;
        if (PlaytestMode) 
        {
            Debug.Log("Playtest mode on!");
        }
        else
        {
            Debug.Log("Playtest mode off!");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
