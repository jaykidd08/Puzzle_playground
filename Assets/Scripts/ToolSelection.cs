using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSelection : MonoBehaviour
{
    public GameObject grappleTool;
    public GameObject platformTool;

    private bool Equipped;
    void Start()
    {
        grappleTool.SetActive(true);
        platformTool.SetActive(false);

        Equipped = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Equipped)
            {
                grappleTool.SetActive(false);
                platformTool.SetActive(true);
                Equipped = false;
            }
            else
            {
                grappleTool.SetActive(true);
                platformTool.SetActive(false);
                Equipped = true;
            }
        }
    }
}
