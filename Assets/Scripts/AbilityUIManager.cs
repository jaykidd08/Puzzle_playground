using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbilityUIManager : MonoBehaviour
{
    public GameObject launcherUI;
    public GameObject MiniManUI;
    public GameObject DimensionalUI;

    private void Start()
    {
        if (ToolSelection.hasLauncher)
        {
            launcherUI.SetActive(true);
        }
        else
        {
            launcherUI.SetActive(false);
        }

        if (ToolSelection.hasMiniMan)
        {
            MiniManUI.SetActive(true);
        }
        else
        {
            MiniManUI.SetActive(false);
        }

        if (ToolSelection.hasDimensionalGoggles)
        {
            DimensionalUI.SetActive(true);
        }
        else
        {
            DimensionalUI.SetActive(false);
        }
    }
}
