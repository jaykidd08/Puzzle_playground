using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PagePickup : MonoBehaviour
{

    public GameObject pageOverlay;
    public TextMeshProUGUI pageText;

    public void DisplayPage(string itemDescription)
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pageOverlay.SetActive(true);
        pageText.text = itemDescription;
    }

    public void HidePage()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pageOverlay.SetActive(false);
        pageText.text = "";
    }
}
